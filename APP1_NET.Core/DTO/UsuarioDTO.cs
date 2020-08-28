using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.DTO
{
    public class UsuarioDTO
    {
        public string ClientId { get; set; }
        public byte[] HashPassword{ get; set; }
    }
}
