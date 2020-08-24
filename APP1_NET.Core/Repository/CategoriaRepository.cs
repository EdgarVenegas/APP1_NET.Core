using APP1_NET.Core.Infraestructure;
using APP1_NET.Core.Model;
using APP1_NET.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Se realizan todas las operaciones necesarias de la lógia 
// para poder llamar los datos desde y hacia nuestra BD. 

namespace APP1_NET.Core.Repository
{
    //Implementación de la Interfaz - : ICategoriaRepository
    public class CategoriaRepository : ICategoriaRepository
    {
        
        // ------------------------------------------------------ //
        private readonly CatalogoDbContext _bdCatalogo;

        public CategoriaRepository(CatalogoDbContext bdCatalogo)
        {
            _bdCatalogo = bdCatalogo;
        }
        // ------------------------------------------------------ //

        public int CreateCategoria(Categoria DatosCategoria)
        {
            _bdCatalogo.Categoria.Add(DatosCategoria);
            _bdCatalogo.SaveChanges();

            return DatosCategoria.IdCategoria;

            throw new NotImplementedException();
        }

        public bool DeleteCategoria(int IdCategoria)
        {
            var item = _bdCatalogo.Categoria.Where(x => x.IdCategoria == IdCategoria).FirstOrDefault();
            _bdCatalogo.Categoria.Remove(item);
            _bdCatalogo.SaveChanges();
            return true;


            throw new NotImplementedException();
        }

        public bool DeleteCategoria(ICollection<int> IdCategoria)
        {

            var ListItem = _bdCatalogo.Categoria.Where(x => IdCategoria.Contains(x.IdCategoria)).ToList();
            _bdCatalogo.Categoria.RemoveRange(ListItem);
            _bdCatalogo.SaveChanges();
            return true;

            throw new NotImplementedException();
        }

        public bool ExistsCategoria(string Nombre)
        {
            return _bdCatalogo.Categoria.Any(x => x.Nombre.ToUpper() == Nombre.ToUpper());

            throw new NotImplementedException();
        }

        public bool ExistsCategoria(int IdCategoria)
        {
            return _bdCatalogo.Categoria.Any(x => x.IdCategoria == IdCategoria);

            throw new NotImplementedException();
        }

        public ICollection<Categoria> GetCategoria()
        {
            return _bdCatalogo.Categoria.ToList();

            throw new NotImplementedException();
        }

        public Categoria GetCategoria(int IdCategoria)
        {
            return _bdCatalogo.Categoria.Where(x => x.IdCategoria == IdCategoria).FirstOrDefault();
            throw new NotImplementedException();
        }

        public Categoria UpdateCategoria(Categoria DatosCategoria)
        {
            var Item = _bdCatalogo.Categoria.Where(x => x.IdCategoria == DatosCategoria.IdCategoria).FirstOrDefault();

            Item.Nombre = DatosCategoria.Nombre;
            Item.ImagenMiniatura = DatosCategoria.ImagenMiniatura;
            Item.ImagenBanner = DatosCategoria.ImagenBanner;
            Item.Activo = DatosCategoria.Activo;
            Item.FechaCreo = DatosCategoria.FechaCreo;
            Item.UsuarioCreo = DatosCategoria.UsuarioCreo;
            Item.FechaCreo = DatosCategoria.FechaCreo;
            Item.UsuarioModifico = DatosCategoria.UsuarioModifico;
            Item.FechaModifico = DatosCategoria.FechaModifico;

            _bdCatalogo.SaveChanges();

            return Item;

            throw new NotImplementedException();
        }

        public ICollection<Categoria> UpdateCategoria(ICollection<Categoria> DatosCategoria)
        {
            var ListItem = _bdCatalogo.Categoria.Where(x => DatosCategoria.Select(i => i.IdCategoria).ToList().Contains(x.IdCategoria)).ToList();

            // ForEach de Entity Framework
            ListItem.ForEach(u =>
            {
                u.Nombre = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.Nombre).FirstOrDefault();
                u.ImagenMiniatura = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.ImagenMiniatura).FirstOrDefault();
                u.ImagenBanner = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.ImagenBanner).FirstOrDefault();
                u.Activo = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.Activo).FirstOrDefault();
                u.FechaCreo = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.FechaCreo).FirstOrDefault();
                u.UsuarioCreo = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.UsuarioCreo).FirstOrDefault();
                u.FechaCreo = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.FechaCreo).FirstOrDefault();
                u.UsuarioModifico = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.UsuarioModifico).FirstOrDefault();
                u.FechaModifico = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.FechaModifico).FirstOrDefault();
            });

            _bdCatalogo.SaveChanges();

            return _bdCatalogo.Categoria.Where(x => DatosCategoria.Select(i => i.IdCategoria).ToList().Contains(x.IdCategoria)).ToList();

            throw new NotImplementedException();
        }

    }
}
