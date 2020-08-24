using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP1_NET.Core.DTO;
using APP1_NET.Core.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP1_NET.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        
        // Una vez creado el controlador, se procede a crear dos variables de solo lecutra.
        
        // - Repositorio de Funciones
        private readonly ICategoriaRepository _CategoriaRepo;
        // - AutoMapper
        private readonly IMapper _Mapper;


        public CategoriaController(ICategoriaRepository CategoriaRepository, IMapper Mapper)
        {
            _CategoriaRepo = CategoriaRepository;
            _Mapper = Mapper;
        }


        // Petición Get
        [HttpGet]
        public ActionResult GetCategoria()
        {
            var LstCategoria = _CategoriaRepo.GetCategoria();
            var LstCategoriaLDTO = new List<CategoriaDTO>();
            foreach (var lst in LstCategoria)
            {
                LstCategoriaLDTO.Add(_Mapper.Map<CategoriaDTO>(lst));

            }

            return Ok(LstCategoriaLDTO);
        }


        [HttpGet("{IdCategoria:int}", Name = "GetCategoria")]
        public ActionResult GetCategoria(int IdCategoria)
        {
            var ItemCategoria = _CategoriaRepo.GetCategoria(IdCategoria);
            if (ItemCategoria == null)
            {
                return NotFound();
            }

            var CategoriaDTO = _Mapper.Map<CategoriaDTO>(ItemCategoria);

            return Ok(CategoriaDTO);
        }


        // Petición Post: Crear contenido
        [HttpPost]
        public IActionResult CreateCategoria([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
            {
                return BadRequest(ModelState);
            }
            else if (_CategoriaRepo.ExistsCategoria(categoriaDTO.Nombre))
            {
                ModelState.AddModelError("", "La Categoria " + categoriaDTO.Nombre + ", ya existe.");
                return StatusCode(404, ModelState);
            }

            var Categoria = _Mapper.Map<Model.Categoria>(categoriaDTO);

            int IdCategoria = _CategoriaRepo.CreateCategoria(Categoria);

            if (IdCategoria == 0)
            {
                ModelState.AddModelError("", "La categoria" + categoriaDTO.Nombre + ", no se pudo crear.");
                return StatusCode(500, ModelState);

            }

            return Ok(IdCategoria);
        }


        // Petición Patch: Actualizar - ID , Route
        [HttpPatch("{IdCategoria:int}", Name = "UpdateCategoria")]
        public IActionResult UpdateCategoria(int IdCategoria, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
            {
                return BadRequest(ModelState);
            }

            var Categoria = _Mapper.Map<Model.Categoria>(categoriaDTO);

            var item = _CategoriaRepo.UpdateCategoria(Categoria);

            if (item == null)
            {
                ModelState.AddModelError("", "La categoria no se pudo actualizar");
                return StatusCode(500, ModelState);
            }

            return Ok(Categoria);

        }


        // Petición Delete: Eliminar - ID , Route
        [HttpDelete("{IdCategoria:int}", Name = "DeleteCategoria")]
        public IActionResult DeleteCategoria(int IdCategoria)
        {
            if (!_CategoriaRepo.ExistsCategoria(IdCategoria))
            {
                return NotFound();
            }

            if (!_CategoriaRepo.DeleteCategoria(IdCategoria))
            {
                ModelState.AddModelError("", "La Categoria no se pudo borrar");
                return StatusCode(500, ModelState);

            }


            return NoContent();
        }
    }
}
