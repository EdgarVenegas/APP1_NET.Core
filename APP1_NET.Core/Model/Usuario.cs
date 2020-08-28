using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.Model
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string ClientId { get; set; }
        //Importante agregar los siguientes campos para el Cifrado. 
        public byte[] HashPassword { get; set; }
        public byte[] SaltPass { get; set; }
    }
}
