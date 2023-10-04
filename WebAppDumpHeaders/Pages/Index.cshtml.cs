using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppDumpHeaders.Pages
{
    public class IndexModel : PageModel
    {
        public int PageViewCount { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            PageViewCount = 1;
        }

        public void OnGet()
        {
            var pageViewCountCookie = Request.Cookies["PageViewCount"];
            CookieOptions option = new()
            {
                Expires = DateTime.Now.AddYears(1)
            };
            if (pageViewCountCookie == null)
            {

                Response.Cookies.Append("PageViewCount", "1", option);
            }
            else
            {
                PageViewCount = int.Parse(pageViewCountCookie) + 1;
                Response.Cookies.Append("PageViewCount", PageViewCount.ToString(), option);
            }

            HttpContext.Response.Headers.Add("HYPHEN-TEST", "TEST-VALUE");
            HttpContext.Response.Headers.Add("UNDERSCORE_TEST", "TEST_VALUE");
        }
    }
}