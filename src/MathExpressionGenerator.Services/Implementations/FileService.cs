namespace MathExpressionGenerator.Services.Implementations
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class FileService : IFileService
    {
        private const string DateTimeFormat = "dd.MM.yyyy HH:mm:ss";

        public void CreateTextFile(string expressionsAsText, string path, bool shouldOpenFile = false)
        {
            var builder = new StringBuilder()
                .AppendLine(DateTime.Now.ToString(DateTimeFormat))
                .AppendLine(new string('-', 19))
                .AppendLine(expressionsAsText);

            this.AppendToFile(path, builder.ToString());

            if (shouldOpenFile)
            {
                this.OpenFile(path);
            }
        }

        public void CreateWordFile(string expressionsAsText, string path, bool shouldOpenFile = false)
        {
            var builder = new StringBuilder()
                .AppendLine(DateTime.Now.ToString(DateTimeFormat))
                .AppendLine(new string('-', 19))
                .AppendLine(expressionsAsText);

            this.AppendToFile(path, builder.ToString());

            if (shouldOpenFile)
            {
                this.OpenFile(path);
            }
        }

        private void AppendToFile(string path, string text)
        {
            var encoding = new UnicodeEncoding();

            var newBytes = encoding.GetBytes(text).ToList();
            List<byte> existingBytes = new List<byte>();

            if (File.Exists(path))
            {
                var bytes = encoding.GetBytes(File.ReadAllText(path));
                existingBytes.AddRange(bytes);
            }

            newBytes.AddRange(existingBytes);

            var wholeStr = encoding.GetString(newBytes.ToArray());

            File.WriteAllText(path, wholeStr);
        }

        private void OpenFile(string path)
        {
            var process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = path;

            process.Start();
        }
    }
}
