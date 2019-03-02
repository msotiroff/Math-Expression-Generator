namespace MathExpressionGenerator.Models.Interfaces
{
    public interface IRepresentable
    {
        string TypeRepresentation { get; }

        string InstanceRepresentation { get; }
    }
}
