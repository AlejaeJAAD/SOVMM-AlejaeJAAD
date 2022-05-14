using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using sovmm_backend.Models;

namespace sovmm_backend.Models
{
    [BsonIgnoreExtraElements]
    public class Presidencias
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string nProyecto { get; set; }
        public string opcElegida { get; set; }
        public string periodo { get; set; }
        public string Objetivo { get; set; }
        public string Justificacion { get; set; }
        public string giroEmpresa { get; set; }
        public string RFC { get; set; }
        public string Domicilio { get; set; }
        public string Colonia { get; set; }
        public string Categoria { get; set; }
        public string Departamento { get; set; }
        public string CP { get; set; }
        public string Fax { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Telefono { get; set; }
        public string Ext { get; set; }
        public string ntEmpresa  { get; set; }
        public string puestoNTE { get; set; }
        public string NFA { get; set; }
        public string puestoNFA { get; set; }
        public string AsesorExterno { get; set; }
        public string puestoAE { get; set; }
        public string ProyectoId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResolutionDate { get; set; }
        public int Status { get; set; }
    }

    public class FullPresidencias
    {
        public string Id { get; set; }
        public User CreatedBy { get; set; }
        public string nProyecto { get; set; }
        public string opcElegida { get; set; }
        public string periodo { get; set; }
        public string Objetivo { get; set; }
        public string Justificacion { get; set; }
        public string giroEmpresa { get; set; }
        public string RFC { get; set; }
        public string Domicilio { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Fax { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Telefono { get; set; }
        public string ntEmpresa { get; set; }
        public string puestoNTE { get; set; }
        public string NFA { get; set; }
        public string puestoNFA { get; set; }
        public string Categoria { get; set; }
        public string Departamento { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResolutionDate { get; set; }
        public int Status { get; set; }
        public List<string> LikedBy { get; set; }
        public Proyecto Proyecto { get; set; }
    }
    
}
