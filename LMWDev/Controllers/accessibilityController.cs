using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace LMWDev.Controllers
{
    public class AccessibilityController : Controller
    {
        private static readonly ActivitySource ActivitySource = new("LMWDev.Accessibility");

        public IActionResult SetBackgroundActive()
        {
            using var activity = ActivitySource.StartActivity("Accessibility.SetBackgroundActive");

            activity?.SetTag("session.id", HttpContext.Session.Id);
            activity?.SetTag("Controller.Route", "search");

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