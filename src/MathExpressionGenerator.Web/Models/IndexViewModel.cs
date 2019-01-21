using MathExpressionGenerator.Common.Languages;
using MathExpressionGenerator.Common.ViewModels;
using MathExpressionGenerator.Models.Enums;
using MathExpressionGenerator.Web.Attribute;
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

        [Range(1, 1000)]
        public int ExpressionsCount { get; set; }
        
        public bool ShouldRandomize { get; set; }

        public string FileExtensionSelected { get; set; }

        public IEnumerable<SelectListItem> SaveAsOptions { get; set; }

        public string Result { get; set; }

        public bool ShowErrors { get; set; }

        public void InitializeSelectLists(
            IEnumerable<ExpressionViewModel> expressions,
            ILanguage language)
        {
            this.SaveAsOptions = new List<SelectListItem>
            {
                new SelectListItem("Text document", ".txt", true),
                new SelectListItem("MS Word document", ".doc", false),
            };

            this.AllExpressionTypes = expressions
                    .Select(et => new SelectListItem(et.ToString(), et.Type.FullName));

            this.AllExpressionOperations = Enum
                .GetValues(typeof(ExpressionOperation))
                .Cast<ExpressionOperation>()
                .Select(eo => new SelectListItem(language.GetPropertyValue(eo.ToString()), eo.ToString()));
        }
    }
}
