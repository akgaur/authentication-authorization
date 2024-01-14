using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedAuthentication.Controllers
{
    public class SecurityController : Controller
    {
        // GET: SecurityController
        public string Index()
        {
            SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecrateKey#9808"));

            var authClaims = new List<Claim>()
            {
                new Claim("admin", "true"),
                new Claim("Issuer", "admin1100"),
                new Claim(JwtRegisteredClaimNames.UniqueName, "akash.gaur@gmail.com")
            };

            var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // GET: SecurityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
