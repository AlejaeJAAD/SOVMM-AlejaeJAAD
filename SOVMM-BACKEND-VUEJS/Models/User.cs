using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace sovmm_backend.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        public string Image { get; set; }
        [Required]
        [Display(Name = "Correo electronico institutocional (Tecnologico de Culiacan)")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Correo electronico personal")]
        public string PersonalEmail { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "Colonia")]
        public string Suburb { get; set; }

        [Display(Name = "Genero")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "CURP")]
        public string Curp { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Direccion")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public string Career { get; set; }

        [Required]
        [Display(Name = "Numero de control")]
        public string Enrollment{ get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public string Department { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Fecha de registro de usuario")]
        public DateTime UserSince { get; set; }

        [Display(Name = "Estatus")]
        public bool Status { get; set; }

        [Display(Name = "Proyectos de residencias asignados")]
        public List<string> AssignedProject { get; set; }
        
	    [Required]
        public int AccessLevel { get; set; }
        public UserCredentials Credentials { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Email}, {Password}";
        }
    }
}

public class UserCredentials
{
    public string Token { get; set; }
    public int ExpirationInDays { get; set; }
}
public class AuthModel
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public bool FromMobile { get; set; }
}
