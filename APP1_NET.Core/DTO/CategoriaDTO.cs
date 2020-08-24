using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.DTO
{
    public class CategoriaDTO 
    {

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }     
        public Guid ImagenMiniatura { get; set; }
        public Guid ImagenBanner { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreo { get; set; }
        public Guid UsuarioCreo { get; set; }
        public DateTime FechaModifico { get; set; }
        public Guid UsuarioModifico { get; set; }

    }
}
