using APP1_NET.Core.DTO;
using APP1_NET.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;

namespace APP1_NET.Core.Mapper
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            // Para hacer la transferencia de datos. 
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }     
    }
}
