using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MongoDB.Driver;
using sovmm_backend.Models;
using sovmm_backend.Services;

namespace sovmm_backend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PresidenciasController : ControllerBase
    {
        private readonly IPresidenciasRepository presidenciasRepository;

        public PresidenciasController(IPresidenciasRepository presidenciasRepository)
        {
            this.presidenciasRepository = presidenciasRepository;
        }
        
        [HttpGet("feed")]
        public List<FullPresidencias> GetFeed()
        {
            return presidenciasRepository.getFeed();
        }

        [HttpGet]
        public List<Presidencias> GetAll()
        {
            return presidenciasRepository.Get();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Presidencias> Get(string id)
        {
            return presidenciasRepository.Get(id);
        }
        
        [HttpGet("user/{id}")]
        public ActionResult<List<Presidencias>> GetByUser(string id)
        {
            return presidenciasRepository.GetByUser(id);
        }

        [HttpPost("new", Name = "NewPresidencias")]
        public ActionResult<Presidencias> Register([FromBody] Presidencias newPresidencias)
        {

            var presidencias = presidenciasRepository.New(newPresidencias);
            if (presidencias.CreatedBy == null)
            {
                return Ok(new {error = "Ya existe un proyecto creado por esa persona", id = presidencias.Id});
            }

            return Ok(presidencias);
        }
        
        [HttpPut("{id}")]
        public ActionResult<User> Update(string id, [FromBody] Presidencias updatedPresidencias)
        {
            var presidencias = presidenciasRepository.Get(id);
            if (presidencias == null) 
            return Ok(new {error = "Presidencias no encontrado."});
            presidenciasRepository.Update(id, updatedPresidencias);

            return Ok(updatedPresidencias);
        }
        
    }
}