using APP1_NET.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.Repository.IRepository
{
    interface IMarcaRepository
    {
        ICollection<Marca> GetMarca();
        Marca GetMarca(int IdMarca);
        bool ExistsMarca(string Nombre);
        bool ExistsMarca(int IdMarca);
        Guid CreateMarca(Marca DatosMarca);
        ICollection<int> CreateMarca(ICollection<Marca> DatosMarca);
        bool DeleteMarca(Guid IdMarca);
        bool DeleteMarca(ICollection<int> IdMarca);
        Marca UpdateMarca(Marca DatosMarca);
        ICollection<Marca> UpdateMarca(ICollection<Marca> DatosMarca);
    }
}
