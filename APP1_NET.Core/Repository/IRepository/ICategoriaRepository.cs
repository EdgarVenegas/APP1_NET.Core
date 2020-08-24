using APP1_NET.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.Repository.IRepository
{
    // Se define la interfaz como publica
    public interface ICategoriaRepository
    {
        //Vistas genérica que retorne todas las categorias. 
        //Nombre: GetCategoria 
        ICollection<Categoria> GetCategoria();

        //Vista que retorne una unica categoria. 
        Categoria GetCategoria(int IdCategoria);

        //Booleano que diga si existe una categoría. 
        bool ExistsCategoria(string Nombre);

        //
        bool ExistsCategoria(int IdCategoria);

        //Devuelve el ID que se le ha asignado a la categoria. 
        int CreateCategoria(Categoria DatosCategoria);

        //Elimina una categoria por medio de un ID. 
        bool DeleteCategoria(int IdCategoria);

        //
        bool DeleteCategoria(ICollection<int> IdCategoria);

        //Nos devuelve como quedo la categoria después de modificarla. 
        Categoria UpdateCategoria(Categoria DatosCategoria);

        ICollection<Categoria> UpdateCategoria(ICollection<Categoria> DatosCategoria);

    }
}
