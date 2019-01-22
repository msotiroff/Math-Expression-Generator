using MathExpressionGenerator.Common.Containers;
using MathExpressionGenerator.Models.Enums;
using MathExpressionGenerator.Models.Interfaces;
using MathExpressionGenerator.Services.Interfaces;
using MathExpressionGenerator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MathExpressionGenerator.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IExpressionExtractor expressionExtractor;
        private readonly IExpressionContainer expressionContainer;
        private readonly IMathExpressionService mathService;
        private readonly FileContentTypes fileContentTypes;

        public HomeController(
            IOptions<FileContentTypes> fileContentTypesOptions,
            ILanguageContainer languageContainer,
            IExpressionExtractor expressionExtractor,
            IExpressionContainer expressionContainer,
            IMathExpressionService mathService)
            : base(languageContainer)
        {
            this.fileContentTypes = fileContentTypesOptions.Value;
            this.expressionExtractor = expressionExtractor;
            this.expressionContainer = expressionContainer;
            this.mathService = mathService;
        }
        
        [HttpGet]
        public IActionResult Index(string expressionOperation = null)
        {
            var success = Enum.TryParse(expressionOperation 
                ?? ExpressionOperation.Addition.ToString(), 
                out ExpressionOperation chosenOperation);

            if (!success)
            {
                chosenOperation = ExpressionOperation.Addition;
            }

            var model = new IndexViewModel();

            model.InitializeSelectLists(
                this.expressionExtractor.Extract(new List<ExpressionOperation> { chosenOperation }),
                CurrentLanguage);
            model.ChosenExpressionOperation = chosenOperation.ToString();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            model.InitializeSelectLists(
                this.expressionExtractor
                    .Extract(new List<ExpressionOperation>
                    {
                        Enum.Parse<ExpressionOperation>(model.ChosenExpressionOperation)
                    }),
                CurrentLanguage);

            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            var chosenExpressionType = Assembly
                .GetAssembly(typeof(IMathExpression))
                .GetType(model.ChosenExpressionType);

            var mathExpressions = this.mathService.GenerateMathExpressions(
                chosenExpressionType,
                model.OperandMinValue,
                model.OperandMaxValue,
                model.ExpressionsCount,
                model.ShouldRandomize);

            if (mathExpressions.Any())
            {
                this.expressionContainer.Add(mathExpressions);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Clear()
        {
            this.expressionContainer.Clear();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task Download()
        {
            var fileBytes = this.expressionContainer.GetExpressionsAsBytes().ToArray();
            var contentType = this.fileContentTypes[".txt"];
            var fileName = CurrentLanguage.ExpressionsFileName;

            if (fileBytes.Length == 0)
            {
                return;
            }

            var response = this.ControllerContext.HttpContext.Response;
            response.ContentType = contentType;
            response.Headers.Add("content-disposition", $"attachment; filename=math-expressions.txt");

            await response.Body.WriteAsync(fileBytes);
        }
    }
}