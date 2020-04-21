using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SwaggerAuth.Contracts;
using SwaggerAuth.Entity.Models;

namespace SwaggerAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IConfiguration _Configuration;
        private IRepositoryWrapper _repowrapper;
        public AccountController(IRepositoryWrapper repositoryWrapper, IConfiguration configuration)
        {
            _repowrapper = repositoryWrapper;
            _Configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public bool Register(User user)
        {
            bool data = _repowrapper.User.Register(user);
            _repowrapper.Save();
            return data;
        }
        [AllowAnonymous]
        [HttpPost("/api/Account/Login")]
        public IActionResult Login(string username, string password)
        {
            IActionResult response = Unauthorized();
            var data = _repowrapper.User.AuthenticateUser(username, password);
            if (data != null)
            {
                var newtoken = GetToken(data);
                response = Ok(new { token = newtoken });
            }
            return response;
        }
        private string GetToken(User model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
            var Credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_Configuration["Jwt:Issuer"],
                _Configuration["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: Credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        [Authorize]
        public   IEnumerable<User> Get()
        {
            return _repowrapper.User.GetAll();
        }
        [HttpPut]
        [Authorize]
        public string Update(User user)
        {
            _repowrapper.User.Update(user);
            _repowrapper.Save();
            return "Update Success!";
        }
        [HttpDelete]
        [Authorize]
        public string DeleteUser(string id)
        {
           
            var data = _repowrapper.User.GetbyId(id);
            if (data != null)
            {
                _repowrapper.User.Delete(data);
                _repowrapper.Save();
                return "User Delete SuccessFully";
            }
            return "Not Found User..!";
        }
    }
}