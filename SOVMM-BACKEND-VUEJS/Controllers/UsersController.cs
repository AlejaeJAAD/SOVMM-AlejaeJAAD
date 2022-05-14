using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using sovmm_backend.Models;
using sovmm_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
namespace sovmm_backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase
    {

        private readonly UsersRepository _usersRepository;
        private readonly string _secret;
        private static Global global = new Global();

        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _usersRepository.LeerTodos();
        }

	[HttpGet("byACLVL/{accesLevel}")]
        public List<User> GetByACLVL(int accessLevel)
        {
	    return _usersRepository.GetByACLVL(accessLevel);
        }

        [AllowAnonymous]
        [HttpGet("name/{id}")]
        public ActionResult<string> GetName(string id)
        {
            var user = _usersRepository.Leer(id);
            var firstName = user.FirstName.Split(" ")[0];
            var lastName = user.LastName?.Split(" ")[0];
            return $"{firstName} {lastName}";
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<User> Get(string id)
        {
            var user = _usersRepository.Leer(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        
        [AllowAnonymous]
        [HttpGet("byEmail/{email}")]
        public ActionResult<User> GetByEmail(string email)
        {
            var user = _usersRepository.GetByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return user.WithoutPassword();
        }
        
        [HttpPost("auth", Name = "AuthUser")]
        public ActionResult<User> Login([FromBody] AuthModel authModel)
        {
            var response = _usersRepository.Login(authModel);
            if (response.Email != null && response.Email == "ENF")
            {
                return Ok(new { error = "Email no encontrado." });
            }
            else if (response.Password != null && response.Password == "PNF")
            {
                return Ok(new { Error = "Contraseña incorrecta." });
            }

            response.Password = null;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<User> Register([FromBody] User newUser)
        {

            newUser.Credentials = new UserCredentials();
            var user = _usersRepository.Crear(newUser);
            if (user == null)
            {
                return Ok(new { error = "El usuario ya existe" });
            }
            return Login(new AuthModel { Email = newUser.Email, Password = newUser.Password });
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<User> Update(string id, [FromBody] User updatedUser)
        {
            var user = _usersRepository.Leer(id);
            if (user == null)
                return Ok(new { error = "Usuario no encontrado." });
            updatedUser.Password = user.Password;
            _usersRepository.Actualizar(id, updatedUser);

            return Ok(updatedUser);
        }

        public class ChangePwModel
        {
            public string CurrPassword { get; set; }
            public string NewPassword { get; set; }
        }
        [HttpPut("password/{id:length(24)}")]
        public ActionResult UpdatePassword(string id, [FromBody] ChangePwModel pwModel)
        {
            var user = _usersRepository.Leer(id);
            if (user == null)
                return Ok(false);
            if (user.Password != pwModel.CurrPassword)
            {
                return Ok(false);
            }
            user.Password = pwModel.NewPassword;
            _usersRepository.Actualizar(id, user);
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            var emp = _usersRepository.Leer(id);
            if (emp == null)
            {
                return NotFound();
            }
            return _usersRepository.Borrar(id);
        }
    }
}