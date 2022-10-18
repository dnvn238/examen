using System;
using System.Collections.Generic;

namespace SOL_DONOVAN_FLORENCIO.DataAccess.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public decimal Idlibro { get; set; }
        public string Isbn { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public DateTime Fechapublicacion { get; set; }
        public string Editorial { get; set; } = null!;

        public virtual ICollection<Prestamo>? Prestamos { get; set; }
    }
}
