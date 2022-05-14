using System;
using System.Collections.Generic;  
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using sovmm_backend.Models;

namespace sovmm_backend.Models
{
    [BsonIgnoreExtraElements]
    public class Proyecto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        public string Type { get; set; }
        public List<string> PrimerAsesoria { get; set; }
        public List<string> PrimerSeguimientoEv { get; set; }
        public List<string> SegundaAsesoria { get; set; }
        public List<string> SegundaSeguimientoEv { get; set; }
        public List<string> TercerAsesoria { get; set; }
        public List<string> TercerSeguimientoEv { get; set; }
        public List<string> RepImages { get; set; }
        public List<string> AnteProy { get; set; }
        public List<string> SolicitudRes { get; set; }
        public List<string> CartPres { get; set; }
        public List<string> ResImages { get; set; }
        public List<string> CartAceptacion { get; set; }
        public bool Status { get; set; }
    }
}