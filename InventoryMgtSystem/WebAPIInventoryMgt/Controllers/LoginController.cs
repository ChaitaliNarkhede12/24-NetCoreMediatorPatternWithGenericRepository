using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIInventoryMgt.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;
        public AuthorizationController(ILoginAppService loginAppService)
        {
            this._loginAppService = loginAppService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            var userList = await _loginAppService.GetUserDetailsByExpression(x => x.UserName == loginModel.UserName && x.Password == loginModel.Password);

            var user = userList.FirstOrDefault();

            if(user == null)
            {
                throw new Exception("User is not valid");
            }

            TokenViewModel tokenModel = _loginAppService.GetTokenModel(user);
            return Ok(tokenModel);
        }
    }
}
