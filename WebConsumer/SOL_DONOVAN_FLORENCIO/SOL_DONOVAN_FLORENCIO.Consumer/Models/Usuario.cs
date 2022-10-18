using System;
using System.Collections.Generic;

namespace SOL_DONOVAN_FLORENCIO.Consumer.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public decimal Idusuario { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;

        public string Dni { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public decimal Estado { get; set; }
        public string Tipousuario { get; set; } = null!;

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
