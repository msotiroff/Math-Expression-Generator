using MathExpressionGenerator.Common;
using MathExpressionGenerator.Common.Containers;
using MathExpressionGenerator.Models.Enums;
using MathExpressionGenerator.Services.Interfaces;
using MathExpressionGenerator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathExpressionGenerator.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IExpressionExtractor expressionExtractor;
        private readonly IExpressionContainer expressionContainer;

        public HomeController(
            ILanguageContainer languageContainer,
            IExpressionExtractor expressionExtractor,
            IExpressionContainer expressionContainer)
            : base(languageContainer)
        {
            this.expressionExtractor = expressionExtractor;
            this.expressionContainer = expressionContainer;
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
            model.ShowErrors = false;
            model.InitializeSelectLists(
                this.expressionExtractor
                    .Extract(new List<ExpressionOperation>
                    {
                        Enum.Parse<ExpressionOperation>(model.ChosenExpressionOperation)
                    }),
                CurrentLanguage);

            if (!this.ModelState.IsValid)
            {
                model.ShowErrors = true;

                return View(model);
            }

            // add to result container
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Clear()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Download(string fileExtension = ".txt")
        {
            throw new NotImplementedException();
        }
    }
}