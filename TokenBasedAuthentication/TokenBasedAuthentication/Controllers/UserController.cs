using Microsoft.AspNetCore.Mvc;
using TokenBasedAuthentication.Data;
using TokenBasedAuthentication.Models;
using TokenBasedAuthentication.Models.Domain;

namespace TokenBasedAuthentication.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _dbContext;

        public UserController(ILogger<HomeController> logger, MyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View(new UserModal());
        }


        [HttpGet]
        public ViewResult List()
        {
            List<UserModal> users = new List<UserModal>();

            var usrList = _dbContext.Users.OrderBy(x=> x.ID).ToList();

            foreach(UserEntity usr in usrList)
            {
                var user = new UserModal()
                {
                    ID = usr.ID,
                    Age = usr.Age,
                    PhoneNumber = usr.PhoneNumber,
                    ConfirmPassword = usr.ConfirmPassword,
                    Password = usr.Password,
                    UserName = usr.UserName,
                    Email = usr.Email,
                    DateOfBirth = usr.DateOfBirth
                };

                users.Add(user);
            }

            return View(users);
        }


        [HttpPost]
        public async Task<ActionResult> Register(UserModal model)
        {
            var user = new UserEntity()
            {
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                ConfirmPassword = model.ConfirmPassword,
                Password = model.Password,
                UserName = model.UserName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

