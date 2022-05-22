using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_mvc.Models
{
    public class Usuario:IObjetoBase
    {
        public int Id { get; set; }
        public int RolUsuarioId { get; set; }
        public RolUsuario RolUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        [Display(Prompt = "Contraseña", Name = "Contraseña")]
        public string Contrasenia { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }
        public string Colonia { get; set; }
        public int Calle { set; get; }
        public int NumeroCasa { get; set; }
        public int EntreCalle1 { set; get; }
        public int EntreCalle2 { set; get; }
    }
}
