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
            LegalModel model = new LegalModel(Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")), jsonLD: null);

            return View(model);
        }
    }
}
