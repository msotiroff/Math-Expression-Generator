using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Division
{
    public abstract class BaseDivision_2v : BaseDivisionEquation
    {
        protected int a;
        protected int b;
        protected int result;
        
        protected BaseDivision_2v(int a, int b)
        {
            this.SetFields(a, b);
        }
        
        private void SetFields(int a, int b)
        {
            if (b == 0)
            {
                b = 1;
            }

            if (a < b)
            {
                if (a == 0)
                {
                    a = 1;
                }

                var copyOfA = a;
                a = b;
                b = copyOfA;
            }

            if (a % b == 0)
            {
                this.a = a;
                this.b = b;
                this.result = a / b;

                return;
            }

            this.SetFields(a + 1, b);
        }
    }
}
