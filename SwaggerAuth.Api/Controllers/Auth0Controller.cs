using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerAuth.Contracts;

namespace SwaggerAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth0Controller : Controller
    {
        private IRepositoryWrapper _repowrapper;
        public Auth0Controller(IRepositoryWrapper repository)
        {
            _repowrapper = repository;
        }

        [HttpPost("Signup")]
        public IActionResult Signup([FromBody]Entity.Models.User signup)
        {
            try
            {
                //getting ManagementAPIClient authority for Auth0 implementation this is used for calling Auth Management API
                ManagementApiClient mac = General.getAuthManagementApiToken();
                UserCreateRequest userCreateRequest = new UserCreateRequest();
                userCreateRequest.Email = signup.Email;
                userCreateRequest.FirstName = signup.Name;
                //userCreateRequest.UserName = signup.UserName;
                userCreateRequest.EmailVerified = true;
                userCreateRequest.Password = signup.Password;
                userCreateRequest.Connection = "Username-Password-Authentication";

                //creating user on atuh0 db
                Auth0.ManagementApi.Models.User newuser = mac.Users.CreateAsync(userCreateRequest).Result;
               
                _repowrapper.User.Register(signup);
                _repowrapper.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;

            }

        }
    }
}