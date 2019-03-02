using MathExpressionGenerator.Models.Interfaces;
using MathExpressionGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathExpressionGenerator.Services.Implementations
{
    public class ExpressionContainer : IExpressionContainer
    {
        private readonly StringBuilder stringBuilder;

        public ExpressionContainer()
        {
            this.stringBuilder = new StringBuilder();
        }

        public void Add(IEnumerable<IRepresentable> representables)
        {
            this.stringBuilder
                    .AppendLine(string.Join(
                        Environment.NewLine,
                        representables.Select(me => me.InstanceRepresentation)));
        }

        public void Clear()
        {
            this.stringBuilder.Clear();
        }

        public IEnumerable<byte> GetExpressionsAsBytes()
        {
            var encoding = new UnicodeEncoding();

            var bytes = encoding.GetBytes(this.stringBuilder.ToString());

            return bytes;
        }

        public string GetExpressionsAsString()
        {
            var expressions = this.stringBuilder.ToString();

            return expressions;
        }
    }
}
