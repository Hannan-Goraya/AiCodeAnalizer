using Microsoft.CodeAnalysis;

namespace AIChatBootAnalizer.Models
{
    public class Issue
    {
        public string Id { get; set; } = "";
        public string Severity { get; set; } = "";
        public string Message { get; set; } = "";
        public int Line { get; set; }      // 1-based
        public int Column { get; set; }    // 1-based
        public string? Suggestion { get; set; }
        public string? FilePath { get; set; }
    }
}
