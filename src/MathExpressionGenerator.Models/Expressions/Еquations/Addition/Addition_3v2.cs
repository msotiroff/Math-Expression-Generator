﻿namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    using MathExpressionGenerator.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class Addition_3v2 : BaseAdditionEquation
    {
        private readonly IList<int> orderedArguments;
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int d;
        
        public Addition_3v2(int a, int b, int c)
        {
            this.orderedArguments = new List<int> { a, b, c }.OrderBy(x => x).ToList();

            this.a = this.orderedArguments[2];
            this.b = this.orderedArguments[1];
            this.c = this.orderedArguments[0];

            this.d = (this.a + this.b) - this.c;
        }
        
        public override string InstanceRepresentation => $"{a} + {base.VariableSymbol} = {c} + {d}";

        public override string TypeRepresentation => $"a + {base.VariableSymbol} = c + d";
    }
}
