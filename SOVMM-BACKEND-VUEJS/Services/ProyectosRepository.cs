using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using sovmm_backend.Models;

namespace sovmm_backend.Services
{
    public interface IProyectosRepository
    {
        public Proyecto Get(string id);
        public Proyecto New(Proyecto newProyecto);
        public List<Proyecto> Get();
        public void Update(string id, Proyecto updatedProyecto);
        public List<Proyecto> GetByPresidencias(string id);
    }
    public class    ProyectosRepository : IProyectosRepository
    {
        private readonly IMongoCollection<Proyecto> _mProyecto;
        public ProyectosRepository(IConnSettings connSettings){
            var mongoClient = new MongoClient(connSettings.ConnUrl);            
            var dB = mongoClient.GetDatabase(connSettings.DbName);
            _mProyecto = dB.GetCollection<Proyecto>(connSettings.ProyectoCollectionName);
        }

        public Proyecto Get(string id)
        {
            return _mProyecto.Find(Proyecto => Proyecto.Id == id).FirstOrDefault();
        }

        public List<Proyecto> Get() => _mProyecto.Find(Proyecto => true).ToList();


        public Proyecto New(Proyecto newProyecto)
        {
            List<Proyecto> lst = Get();
            
            _mProyecto.InsertOne(newProyecto);
            return newProyecto;        
        }

        public void Update(string id, Proyecto updatedProyecto)
        {
            _mProyecto.ReplaceOne(Proyecto => Proyecto.Id == id, updatedProyecto);       
        }
        public List<Proyecto> GetByPresidencias(string proyectoId)
        {
            return _mProyecto.Find(Proyecto => Proyecto.Id == proyectoId).ToList();
        }
    }
}
