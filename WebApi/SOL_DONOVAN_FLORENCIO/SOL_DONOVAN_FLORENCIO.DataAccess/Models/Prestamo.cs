using System;
using System.Collections.Generic;

namespace SOL_DONOVAN_FLORENCIO.DataAccess.Models
{
    public partial class Prestamo
    {
        public decimal Idprestamo { get; set; }
        public decimal Idlibro { get; set; }
        public decimal Idusuario { get; set; }
        public DateTime Fechaprestamo { get; set; }
        public DateTime Fechadevolucion { get; set; }
        public string? Tipolectura { get; set; }

        public virtual Libro? Libro { get; set; } = null!;
        public virtual Usuario? Usuario { get; set; } = null!;
    }
}
