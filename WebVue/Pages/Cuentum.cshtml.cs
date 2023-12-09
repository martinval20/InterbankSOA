using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebVue.Pages
{
    public class CuentumModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public CuentumModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}