using AIChatBootAnalizer.Models;

namespace AIChatBootAnalizer.Services
{
    public static class CodeAnalyzer
    {
        public static List<string> Run(string code, string language)
        {
            var issues = new List<string>();

            if (language.ToLower() == "csharp")
            {
                if (code.Contains("Console.Write(") && !code.Contains(";"))
                    issues.Add("Missing semicolon in C# code.");
            }

            if (language.ToLower() == "javascript")
            {
                if (code.Contains("==") && !code.Contains("==="))
                    issues.Add("Consider using strict equality (===) in JavaScript.");
            }

            if (language.ToLower() == "python")
            {
                if (code.Contains("print ") && !code.Contains("("))
                    issues.Add("Python 3 requires parentheses in print().");
            }

            return issues;
        }
    }
}
