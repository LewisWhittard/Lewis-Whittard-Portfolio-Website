using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMWDev.Controllers
{
    public class AccessibilityController : Controller
    {
        public IActionResult SetBackgroundActive()
        {
            // Read current value (default to false)
            bool disabled = HttpContext.Session.GetString("BackgroundDisabled") == "true";

            // Toggle it
            HttpContext.Session.SetString("BackgroundDisabled", (!disabled).ToString().ToLower());

            // Get referer
            var referer = Request.Headers["Referer"].ToString();

            // Build your base URL (authority only)
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            // Validate referer
            if (string.IsNullOrWhiteSpace(referer) ||
                !Uri.TryCreate(referer, UriKind.Absolute, out var refererUri) ||
                !refererUri.Host.Equals(Request.Host.Host, StringComparison.OrdinalIgnoreCase))
            {
                // Fallback to home
                return Redirect(Url.Action("Index", "Home"));
            }

            // Safe redirect
            return Redirect(referer);
        }
    }
}
