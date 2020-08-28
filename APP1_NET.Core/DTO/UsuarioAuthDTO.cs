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
        
        [Required]
        public string ClientId { get; set; }
        
        //Password
        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
