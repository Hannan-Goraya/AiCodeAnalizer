namespace AIChatBootAnalizer.Models
{
    public class CodeRequest
    {
        public string Code { get; set; }
        public string Language { get; set; } 

    public class AnalysisResult
    {
        public List<string> Issues { get; set; } = new();
        public string Explanation { get; set; }
    }
}
