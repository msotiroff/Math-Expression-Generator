namespace MathExpressionGenerator.Services.Interfaces
{
    public interface IFileService
    {
        void CreateTextFile(string expressionsAsText, string path, bool shouldOpenFile = false);

        void CreateWordFile(string expressionsAsText, string path, bool shouldOpenFile = false);
    }
}
