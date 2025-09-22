namespace AIChatBootAnalizer.Models
{
    public class AnalysisResult
    {
        public List<Issue> Issues { get; set; } = new();
        public bool Success => Issues.Count == 0;
    }
}
