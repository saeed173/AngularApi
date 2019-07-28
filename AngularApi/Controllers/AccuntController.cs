using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AngularApi.Controllers
{
    
   
    [Route("api/[controller]")]
    [ApiController]
    public class AccuntController : ControllerBase
    {
        public class Reg
        {
            public string Email { get;set; }
            public string Password { get; set; }
          
          

        }


        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        
        public AccuntController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;


        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reg reg)
        {
            var user = new IdentityUser() { Email = reg.Email, UserName = reg.Email };
            var result = await userManager.CreateAsync(user, reg.Password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await signInManager.SignInAsync(user, isPersistent: false);

            return Ok(creattoken(user));

        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody]Reg reg)
        {
            var result = await signInManager.PasswordSignInAsync(reg.Email, reg.Password, false, false);
            if(! result.Succeeded)
            {
                return BadRequest();
            }
            var user = await userManager.FindByEmailAsync(reg.Email);
            return Ok(creattoken(user));
        }

        string creattoken(IdentityUser user)
        {
            var claims = new Claim[]
           {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
           };


            var sighiningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the secret key"));
            var sighiningCredentials = new SigningCredentials(sighiningKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials: sighiningCredentials, claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

    }
}