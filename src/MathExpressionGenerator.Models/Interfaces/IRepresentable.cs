namespace MathExpressionGenerator.Models.Interfaces
{
    public interface IRepresentable
    {
        string TypeRepresentation { get; }

        string ObjectRepresentation { get; }
    }
}
