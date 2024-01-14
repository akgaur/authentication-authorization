using Microsoft.AspNetCore.Mvc;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ViewResult Get(int id)
        {
            return View();
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Register(UserModal user)
        {
            return View();
        }
    }
}

