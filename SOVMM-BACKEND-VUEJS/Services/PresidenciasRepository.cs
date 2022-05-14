using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using sovmm_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace sovmm_backend.Services
{
    public interface IPresidenciasRepository
    {
        public Presidencias Get(string id);
        public Presidencias New(Presidencias newPresidencias);
        public List<Presidencias> Get();
        List<FullPresidencias> getFeed();
        public void Update(string id, Presidencias updatedPresidencias);
        public  List<Presidencias> GetByUser(string id);
        List<FullPresidencias> GetByUserComplete(string id);
    }
    public class PresidenciasRepository : IPresidenciasRepository
    {
        private readonly IMongoCollection<Presidencias> _mPresidencias;
        private readonly IMongoCollection<User> _mUsers;
        private readonly IMongoCollection<Proyecto> _mProyectos;

        public PresidenciasRepository(IConnSettings connSettings)
        {
            var mongoClient = new MongoClient(connSettings.ConnUrl);
            var dB = mongoClient.GetDatabase(connSettings.DbName);
            _mPresidencias = dB.GetCollection<Presidencias>(connSettings.PresidenciaCollectionName);
            _mUsers = dB.GetCollection<User>(connSettings.UserCollectionName);
            _mProyectos = dB.GetCollection<Proyecto>(connSettings.ProyectoCollectionName);
            
        }
        public List<FullPresidencias> getFeed()
        {
            var lFR = new List<FullPresidencias>();
            foreach (var presidencias in Get())
            {
                var user = _mUsers.Find(userF => userF.Id == presidencias.CreatedBy).FirstOrDefault();
                user.Password = null;
                var proyecto = _mProyectos.Find(proyectoF => proyectoF.Id == presidencias.ProyectoId).FirstOrDefault();
                var fullPresidencias = new FullPresidencias();
                fullPresidencias.nProyecto = presidencias.nProyecto;
                fullPresidencias.opcElegida = presidencias.opcElegida;
                fullPresidencias.periodo = presidencias.periodo;
                fullPresidencias.Objetivo = presidencias.Objetivo;
                fullPresidencias.Justificacion = presidencias.Justificacion;
                fullPresidencias.giroEmpresa = presidencias.giroEmpresa;
                fullPresidencias.RFC = presidencias.RFC;
                fullPresidencias.Domicilio = presidencias.Domicilio;
                fullPresidencias.Colonia = presidencias.Colonia;
                fullPresidencias.CP = presidencias.CP;
                fullPresidencias.Fax = presidencias.Fax;
                fullPresidencias.Ciudad = presidencias.Ciudad;
                fullPresidencias.Categoria = presidencias.Categoria;
                fullPresidencias.Departamento = presidencias.Departamento;
                fullPresidencias.Estado = presidencias.Estado;
                fullPresidencias.Telefono = presidencias.Telefono;
                fullPresidencias.ntEmpresa = presidencias.ntEmpresa;
                fullPresidencias.puestoNTE = presidencias.puestoNTE;
                fullPresidencias.NFA = presidencias.NFA;
                fullPresidencias.puestoNFA = presidencias.puestoNFA;
                fullPresidencias.Id = presidencias.Id;
                fullPresidencias.Proyecto = proyecto;
                fullPresidencias.Status = presidencias.Status;
                fullPresidencias.CreatedDate = presidencias.CreatedDate;
                fullPresidencias.ResolutionDate = presidencias.ResolutionDate;
                fullPresidencias.CreatedBy = user;
                lFR.Add(fullPresidencias);
            }

            return lFR;

        }

        public List<FullPresidencias> GetByUserComplete(string id)
        {
            var lFR = new List<FullPresidencias>();
            foreach (var presidencias in GetByUser(id))
            {
                var user = _mUsers.Find(userF => userF.Id == presidencias.CreatedBy).FirstOrDefault();
                user.Password = null;
                var proyecto = _mProyectos.Find(proyectoF => proyectoF.Id == presidencias.ProyectoId).FirstOrDefault();
                var fullPresidencias = new FullPresidencias();
                fullPresidencias.nProyecto = presidencias.nProyecto;
                fullPresidencias.opcElegida = presidencias.opcElegida;
                fullPresidencias.periodo = presidencias.periodo;
                fullPresidencias.Objetivo = presidencias.Objetivo;
                fullPresidencias.Justificacion = presidencias.Justificacion;
                fullPresidencias.Id = presidencias.Id;
                fullPresidencias.Proyecto = proyecto;
                fullPresidencias.Status = presidencias.Status;
                fullPresidencias.CreatedDate = presidencias.CreatedDate;
                fullPresidencias.ResolutionDate = presidencias.ResolutionDate;
                fullPresidencias.CreatedBy = user;
                lFR.Add(fullPresidencias);
            }

            return lFR;
        }

        public Presidencias Get(string id)
        {
            return _mPresidencias.Find(presidencias => presidencias.Id == id).FirstOrDefault();
        }

        public List<Presidencias> Get() => _mPresidencias.Find(presidencias => true).ToList();


        public Presidencias New(Presidencias newPresidencias)
        {
            _mPresidencias.InsertOne(newPresidencias);
            return newPresidencias;  
      
        }

        public void Update(string id, Presidencias updatedPresidencias)
        {
            _mPresidencias.ReplaceOne(presidencias => presidencias.Id == id, updatedPresidencias);       
        }
        
        public List<Presidencias> GetByUser(string id)
        {
            return _mPresidencias.Find(presidencias => presidencias.CreatedBy == id).ToList();
        }

    }
}
