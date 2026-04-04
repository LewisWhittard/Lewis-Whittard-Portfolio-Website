using LMWDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMWDev.Controllers
{
    public class LegalController : Controller
    {
        [Route("legal")]
        public IActionResult index()
        {
            var cookieValue = HttpContext.Session.GetString("CookieApproved");

            // Variable 1: is it set?
            bool isCookieSet = cookieValue != null;

            // Variable 2: the actual value (true/false), defaulting to false if unset
            bool CookieApproved = bool.TryParse(cookieValue, out var parsed) && parsed;

            LegalModel model = new LegalModel(Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")), jsonLD: null);

            return View(model);
        }
    }
}
