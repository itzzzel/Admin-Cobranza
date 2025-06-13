using Microsoft.AspNetCore.Mvc;
using App_Cobranza.Models;
namespace App_Cobranza.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
