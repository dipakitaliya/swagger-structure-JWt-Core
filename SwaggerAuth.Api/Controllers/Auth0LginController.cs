using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerAuth.Contracts;
using SwaggerAuth.Entity;

namespace SwaggerAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth0LginController : Controller
    {
        private readonly RepoContext _context;
        public Auth0LginController(RepoContext context)
        {
            _context = context;
        }
        //private IRepositoryWrapper _repowrapper;
        //public Auth0LginController(IRepositoryWrapper repository)
        //{
        //    _repowrapper = repository;
        //}
        //[HttpPost]
        //public bool Register(Entity.Models.User user)
        //{
        //    ManagementApiClient mac = General.getAuthManagementApiToken();
        //    UserCreateRequest userCreate = new UserCreateRequest();
        //    userCreate.Email = user.Email;
        //    userCreate.EmailVerified = true;
        //    userCreate.UserName = user.UserName;
        //    userCreate.FirstName = user.Name;
        //    userCreate.Password = user.Password;
        //    userCreate.Connection = "UserName-password-Authentication";

        //    Auth0.ManagementApi.Models.User a0user = mac.Users.CreateAsync(userCreate).Result;
        //    bool data = _repowrapper.User.Register(user);
        //    _repowrapper.Save();
        //    return data;
        //}
        [HttpPost]
        public async Task<IActionResult> Regiser(Entity.Models.User user)
        {
            ManagementApiClient mac = General.getAuthManagementApiToken();
            UserCreateRequest userCreate = new UserCreateRequest();
            userCreate.Email = user.Email;
            userCreate.EmailVerified = true;
            userCreate.UserName = user.UserName;
            userCreate.FirstName = user.Name;
            userCreate.Password = user.Password;
            userCreate.Connection = "Username-Password-Authentication";
            try
            {

                Auth0.ManagementApi.Models.User a0user =  mac.Users.CreateAsync(userCreate).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {

                throw;
            }
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}