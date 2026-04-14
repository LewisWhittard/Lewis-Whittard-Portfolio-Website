using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMWDev.Controllers
{
    public class AccessibilityController : Controller
    {
        public IActionResult SetBackgroundActive()
        {
            bool disabled = HttpContext.Session.GetString("BackgroundDisabled") == "true";
            HttpContext.Session.SetString("BackgroundDisabled", (!disabled).ToString().ToLower());

            var referer = Request.Headers["Referer"].ToString();

            if (string.IsNullOrWhiteSpace(referer) ||
                !Uri.TryCreate(referer, UriKind.Absolute, out var refererUri) ||
                !refererUri.Host.Equals(Request.Host.Host, StringComparison.OrdinalIgnoreCase))
            {
                return Redirect(Url.Action("Index", "Home"));
            }

            return Redirect(referer);
        }
    }
}