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
    public class ProyectosController : ControllerBase
    {
        private readonly IProyectosRepository proyectosRepository;

        public ProyectosController(IProyectosRepository proyectosRepository)
        {
            this.proyectosRepository = proyectosRepository;
        }

        [HttpGet]
        public List<Proyecto> GetAll()
        {
            return proyectosRepository.Get();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Proyecto> Get(string id)
        {
            return proyectosRepository.Get(id);
        }
        [HttpGet("presidencias/{id}")]
        public ActionResult<List<Proyecto>> GetByPresidencias(string id)
        {
            return proyectosRepository.GetByPresidencias(id);
        }

        [HttpPost("new", Name = "NewProyecto")]
        public ActionResult<Proyecto> Register([FromBody] Proyecto newProyecto){

            var proyecto = proyectosRepository.New(newProyecto);
            if(proyecto == null){
                return Ok(new {error = "Proyecto ya registrado.", id=proyecto.Id});
            }
            
            return Ok(proyecto);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Update(string id, [FromBody] Proyecto updatedProyecto)
        {
            var proyecto = proyectosRepository.Get(id);
            if (proyecto == null) 
                return Ok(new {error = "Usuario no encontrado."});
            proyectosRepository.Update(id, updatedProyecto);

            return Ok(updatedProyecto);
        }
    }
}