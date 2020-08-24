using APP1_NET.Core.DTO;
using APP1_NET.Core.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APP1_NET.Core.Mapper
{
    // Profile para insertar la librería de AutoMapper
    public class CategoriaMapper : Profile
    {
        public CategoriaMapper()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
