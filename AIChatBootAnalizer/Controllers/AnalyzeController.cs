using AIChatBootAnalizer.Models;
using AIChatBootAnalizer.Services;
using Microsoft.AspNetCore.Mvc;
using static AIChatBootAnalizer.Models.CodeRequest;

namespace AIChatBootAnalizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyzeController : ControllerBase
    {
        private readonly AiService _aiService;

        public AnalyzeController(AiService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost]
        public async Task<ActionResult<AnalysisResult>> Analyze([FromBody] CodeRequest request)
        {
            var issues = CodeAnalyzer.Run(request.Code, request.Language);
            var explanation = await _aiService.ExplainAsync(request.Code, issues);

            return Ok(new AnalysisResult
            {
                Issues = issues,
                Explanation = explanation
            });
        }
    }
}
