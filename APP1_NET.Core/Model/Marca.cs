using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APP1_NET.Core.Model
{
    [Table("Marca", Schema = "Cat")]
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public Guid Logo { get; set; }

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
