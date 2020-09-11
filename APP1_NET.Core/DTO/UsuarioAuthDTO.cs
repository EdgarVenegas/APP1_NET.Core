using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.DTO
{
    public class UsuarioAuthDTO
    {
        [Key]
        public int IdUsuario { get; set; }
        
        [Required (ErrorMessage = "El nombre de usuario Correo o Guid es necesario")]
        public string ClientId { get; set; }
        
        //Password
        [Required (ErrorMessage = "La contraseña es requerida")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Longitud no valida debe ser entre 6 y 12")]
        public string Password { get; set; }
    }
}
