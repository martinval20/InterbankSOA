using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebVue.Pages
{
    public class TiposCuentumModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public TiposCuentumModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}