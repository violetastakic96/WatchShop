using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.User;
using Business.DataTransferObjects;
using Business.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUserCommand _login;
        private readonly Encryption _enc;

        public AuthController(ILoginUserCommand login, Encryption enc)
        {
            _login = login;
            _enc = enc;
        }

        // POST: api/Auth
        [HttpPost]
        public IActionResult Post([FromBody] LoginUser dto)
        {

            var user = _login.Execute(dto);

            var stringObjekat = JsonConvert.SerializeObject(user);

            var encryped = _enc.EncryptString(stringObjekat);

            return Ok(new { token = encryped });
        }
        [HttpGet("decode")]
        public IActionResult Decode([FromBody]string value)
        {

            var decodedString = _enc.DecryptString(value);
            decodedString = decodedString.Replace("\f", "");
            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }

    }
}
