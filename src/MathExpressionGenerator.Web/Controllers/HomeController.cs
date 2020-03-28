using DotNetExtensions.Common;
using MathExpressionGenerator.Common;
using MathExpressionGenerator.Common.Containers;
using MathExpressionGenerator.Models.Enums;
using MathExpressionGenerator.Models.Interfaces;
using MathExpressionGenerator.Services.Interfaces;
using MathExpressionGenerator.Web.Abstractions;
using MathExpressionGenerator.Web.Infrastructure.Extensions;
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
        private readonly IUserSessionContainer sessionContainer;
        private readonly IMathExpressionService mathService;
        private readonly FileContentTypes fileContentTypes;

        public HomeController(
            IOptions<FileContentTypes> fileContentTypesOptions,
            ILanguageContainer languageContainer,
            IExpressionExtractor expressionExtractor,
            IUserSessionContainer sessionContainer,
            IMathExpressionService mathService)
            : base(languageContainer)
        {
            this.fileContentTypes = fileContentTypesOptions.Value;
            this.expressionExtractor = expressionExtractor;
            this.sessionContainer = sessionContainer;
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
                this.HttpContext.GetLanguageFromCookie());
            model.ChosenExpressionOperation = chosenOperation.ToString();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (model.SelectedVariableSymbol.IsNotNullOrWhiteSpace())
            {
                Constants.VariableSymbol = model.SelectedVariableSymbol;
            }

            model.InitializeSelectLists(
                this.expressionExtractor.Extract(new List<ExpressionOperation>
                    {
                        Enum.Parse<ExpressionOperation>(model.ChosenExpressionOperation)
                    }),
                this.HttpContext.GetLanguageFromCookie());

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
                model.ShouldRandomize,
                model.SelectedVariableSymbol);

            if (mathExpressions.Any())
            {
                await this.sessionContainer.AddAsync(this.HttpContext, mathExpressions);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Clear()
        {
            await this.sessionContainer.ClearAsync(this.HttpContext);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Download()
        {
            var fileBytes = (await this.sessionContainer.GetExpressionsAsBytesAsync(
                this.HttpContext)).ToArray();
            var contentType = this.fileContentTypes[".txt"];
            var fileName = 
                $"{this.HttpContext.GetLanguageFromCookie().ExpressionsFileName}.txt";

            if (fileBytes.Length == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return File(fileBytes, contentType, fileName);
        }
    }
}