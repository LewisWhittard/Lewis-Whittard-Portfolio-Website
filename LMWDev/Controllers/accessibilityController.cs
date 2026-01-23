using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMWDev.Controllers
{
    public class accessibilityController : Controller
    {
        public IActionResult SetBackgroundActive()
        {
            // Read current value (default to false)
            bool disabled = HttpContext.Session.GetString("BackgroundDisabled") == "true";

            // Toggle it
            HttpContext.Session.SetString("BackgroundDisabled", (!disabled).ToString().ToLower());

            // Build the current URL
            var url = Request.Headers["Referer"].ToString();

            
            if (!Url.IsLocalUrl(url))
            {
                url = Url.Action("Index", "Home"); // fallback
            }

            // Redirect back to the page
            return Redirect(url);
        }
    }
}
