using APP1_NET.Core.Infraestructure;
using APP1_NET.Core.Model;
using APP1_NET.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CatalogoDbContext _bdCatalogo;
        public UsuarioRepository(CatalogoDbContext bdCatalogo)
        {
            _bdCatalogo = bdCatalogo;
        }

        public bool ExisteUsuario(string UsuarioClientID)
        {
            return _bdCatalogo.Usuario.Any(x=>x.ClientId == UsuarioClientID);
            throw new NotImplementedException();
        }

        public Usuario GetUsuario(int IdUsuario)
        {
            var item = _bdCatalogo.Usuario.Where(x => x.IdUsuario == IdUsuario).FirstOrDefault();
                return item;
            throw new NotImplementedException();
        }

        public ICollection<Usuario> GetUsuarios()
        {
            var ListUsuarios = _bdCatalogo.Usuario.ToList();
            return ListUsuarios;
            throw new NotImplementedException();
        }

        public Usuario Login(string usuario, string Password)
        {
            var usuariocredencial = _bdCatalogo.Usuario.Where(x => x.ClientId == usuario).FirstOrDefault();
            if (usuariocredencial == null)
            {
                return null;
            }

            if(!Criptography.ValidacionPassword(Password, usuariocredencial.HashPassword, usuariocredencial.SaltPass))
            {
                return null;
            }

            return usuariocredencial;

            throw new NotImplementedException();
        }

        public int Registrar(Usuario usuario, string Password)
        {
            byte[] HashPassword, SaltPassword;

            Criptography.CrearPasswordEncriptado(Password, out HashPassword, out SaltPassword);

            usuario.HashPassword = HashPassword;
            usuario.SaltPass = SaltPassword;
            _bdCatalogo.Usuario.Add(usuario);

            _bdCatalogo.SaveChanges();

            return usuario.IdUsuario;

            throw new NotImplementedException();
        }
    }
}
