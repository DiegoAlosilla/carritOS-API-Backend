using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carritOSCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {

        //private IActionResult BuildToken(UserInfo userInfo)
        //{
        //    var claims = new[]
        //    {
        //            new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //        };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdlkajndlasndakjlajkhagsdjkhagdjaldgadoadgapadgoauhdguegauvouljhfabjabclhabscaosbdoablajnbdaljfhaoulidgaodjgh"));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var expiration = DateTime.UtcNow.AddHours(1);

        //    JwtSecurityToken token = new JwtSecurityToken(
        //       issuer: "alosilla.com",
        //       audience: "alosilla.com",
        //       claims: claims,
        //       expires: expiration,
        //       signingCredentials: creds);

        //    return Ok(new
        //    {
        //        token = new JwtSecurityTokenHandler().WriteToken(token),
        //        expiration = expiration
        //    });

        //}
    }
}