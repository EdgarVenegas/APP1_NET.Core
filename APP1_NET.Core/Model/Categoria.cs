using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

// Definir nuestras clases en el Modelo:
// Las clases sirven para generar nuestra tabla. 

// TABLA: Categoria
namespace APP1_NET.Core.Model
{
    
    // Data Annotations
    [Table("Categoria", Schema = "Cat")]         //BD                       //Se agrego la librería : System.ComponentModel.DataAnnotations.Schema
    public class Categoria                       //Tabla
    {
        [Key]                                    //PK   AI                  //Se agrego la librería : System.ComponentModel.DataAnnotations;
        public int IdCategoria { get; set; }

        [Required]                               // NOT NULL
        [StringLength(50)]                       // VARCHAR
        public string Nombre { get; set; }       // Nombre del Campo

        [Required]
        public Guid ImagenMiniatura { get; set; }
        public Guid ImagenBanner { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaCreo { get; set; }

        [Required]
        public Guid UsuarioCreo { get; set; }
        public DateTime FechaModifico { get; set; }
        public Guid UsuarioModifico { get; set; }
    }

}


