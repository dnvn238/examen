using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOL_DONOVAN_FLORENCIO.Consumer.Models
{
    public partial class Prestamo
    {
        [Key]
        public decimal Idprestamo { get; set; }
        public decimal Idlibro { get; set; }
        public decimal Idusuario { get; set; }
        public DateTime Fechaprestamo { get; set; }
        public DateTime Fechadevolucion { get; set; }
        public string? Tipolectura { get; set; }

        [ForeignKey("Idlibro")]
        public virtual Libro Libro { get; set; } 

        [ForeignKey("Idusuario")]
        public virtual Usuario Usuario { get; set; } 
    }
}

