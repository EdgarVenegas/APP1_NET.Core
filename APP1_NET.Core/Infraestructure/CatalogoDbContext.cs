using APP1_NET.Core.Model;                  //Categoria
using Microsoft.EntityFrameworkCore;        //DbContext
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.Infraestructure
{
    // Especificar el contexto a utilizar. "DbContext " 
    public class CatalogoDbContext : DbContext
    {

        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base (options)
        {
            
        }

        // Agregar todas las tablas / contexto
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        // Al realizar la migración obtendra las dos clases definidas y las va a convertir en tablas. 
    }
}
