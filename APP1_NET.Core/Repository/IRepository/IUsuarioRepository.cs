using APP1_NET.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int IdUsuario);
        bool ExisteUsuario(string UsuarioClientID);
        Usuario Login(string usuario, string Password);
        int Registrar(Usuario usuario, string Password);
    }
}
