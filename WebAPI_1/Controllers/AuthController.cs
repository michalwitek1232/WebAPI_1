using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_1.Data;
using WebAPI_1.DTOs;
using WebAPI_1.Models;

namespace WebAPI_1.Controllers
{
    [Route("api/[Auth]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;

        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("{register}")]


        //public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
        //{
        //    UserForRegisterDTO.Username = UserForRegisterDTO.Username.ToLower();

        //    if (await _repository.UserExist(UserForRegisterDTO.Username))
        //        return BadRequest("Użytkownik o takiej nazwie już istnieje");

        //    var userToCreate = new Models.User { Username = UserForRegisterDTO.Username };

        //    var createdUser = await _repository.Register(userToCreate, UserForRegisterDTO.Password);

        //    return StatusCode(201);
        //}

        [HttpPost("{Register}")]
        public ActionResult<object> Register([FromBody] DTOs.User userModel)
        {
            try
            {
                UserForRegisterDTO.Username = userModel.Username;

                UserForRegisterDTO.Username = userModel.Password;

                return UserForRegisterDTO.Username;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;

        }
    }
}