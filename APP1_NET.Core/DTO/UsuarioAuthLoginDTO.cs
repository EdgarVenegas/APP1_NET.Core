using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.DTO
{
    public class UsuarioAuthLoginDTO
    {
        [Required]
        public string ClientId { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
