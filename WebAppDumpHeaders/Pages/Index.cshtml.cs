using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppDumpHeaders.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpContext.Response.Headers.Add("HYPHEN-TEST", "TEST-VALUE");
            HttpContext.Response.Headers.Add("UNDERSCORE_TEST", "TEST_VALUE");
        }
    }
}