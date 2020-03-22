using MathExpressionGenerator.Common;
using MathExpressionGenerator.Common.Languages;
using MathExpressionGenerator.Common.ViewModels;
using MathExpressionGenerator.Models.Enums;
using MathExpressionGenerator.Web.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MathExpressionGenerator.Web.Models
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.OperandMinValue = 1;
            this.OperandMaxValue = 10;
            this.ExpressionsCount = 10;
            this.ShouldRandomize = true;
        }

        [Required]
        public string ChosenExpressionType { get; set; }

        public IEnumerable<SelectListItem> AllExpressionTypes { get; set; }

        public string ChosenExpressionOperation { get; set; }

        public IEnumerable<SelectListItem> AllExpressionOperations { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int OperandMinValue { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        [EqualOrGreaterThan(nameof(OperandMinValue))]
        public int OperandMaxValue { get; set; }

        [Range(1, Constants.ExpressionsCountMaxValue)]
        public int ExpressionsCount { get; set; }
        
        public bool ShouldRandomize { get; set; }
        
        public string Result { get; set; }

        public string SelectedVariableSymbol { get; set; }

        public IEnumerable<SelectListItem> VariableSymbolItems =>
            Constants.AllPossibleVarialbeSymbols
            .Select(vs => new SelectListItem(vs, vs, vs == this.SelectedVariableSymbol))
            .ToArray();

        public void InitializeSelectLists(
            IEnumerable<ExpressionViewModel> expressions,
            ILanguage language)
        {
            this.AllExpressionTypes = expressions
                    .Select(et => new SelectListItem(et.ToString(), et.Type.FullName));

            this.AllExpressionOperations = Enum
                .GetValues(typeof(ExpressionOperation))
                .Cast<ExpressionOperation>()
                .Select(eo => new SelectListItem(language.GetPropertyValue(eo.ToString()), eo.ToString()));
        }
    }
}
