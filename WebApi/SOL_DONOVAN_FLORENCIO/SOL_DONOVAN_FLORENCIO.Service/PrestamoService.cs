using Microsoft.EntityFrameworkCore;
using SOL_DONOVAN_FLORENCIO.DataAccess.Models;

namespace SOL_DONOVAN_FLORENCIO.Service
{
    public class PrestamoService : IPrestamoService
    {
        public readonly ModelContext _context;
        public PrestamoService(ModelContext context)
        {
            _context = context;
        }

        public async Task<Response<IEnumerable<Prestamo>>> GetAll()
        {
            var res = new Response<IEnumerable<Prestamo>>();

            var list = await _context.Prestamos
                .Include("Usuario")
                .Include("Libro")
                .ToListAsync();

            if (list != null)
                res.Entity = list;
            else
                res.InternalServerError("Error GetAll");

            return res;
        }

        public async Task<Response<Prestamo>> GetById(decimal id)
        {
            var res = new Response<Prestamo>();
            var Prestamo = await _context.Prestamos.FirstOrDefaultAsync(x => x.Idprestamo == id);

            if (Prestamo != null)
                res.Entity = Prestamo;
            else
                res.BadRequest("El id no esta registrado en la BD");

            return res;
        }

        public async Task<Response<Prestamo>> Post(Prestamo Prestamo)
        {
            var res = new Response<Prestamo>();

            try
            {
                if ( CantidadLibrosPrestados(Prestamo.Idusuario) < 3)
                {
                    await _context.Prestamos.AddAsync(Prestamo);
                    await _context.SaveChangesAsync();
                    Prestamo.Idprestamo = await _context.Prestamos.MaxAsync(u => u.Idprestamo);

                    res.Entity = Prestamo;
                } else
                {
                    res.ReglaNegocioError("Cantidad de Libros maximo permitido");
                }

            }
            catch (DbUpdateException ex)
            {
                res.InternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<Response<Prestamo>> Put(Prestamo Prestamo)
        {
            var res = new Response<Prestamo>();

            _context.Entry(Prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                res.Entity = Prestamo;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var c = await _context.Prestamos.FirstOrDefaultAsync(x => x.Idprestamo == Prestamo.Idprestamo);
                if (c == null)
                    res.BadRequest("Id no registrado en la BD");
                else
                    res.InternalServerError(ex.Message);
            }

            return res;

        }

        public async Task<Response<bool>> Delete(decimal id)
        {
            var res = new Response<bool>();
            var c = await _context.Prestamos.FirstOrDefaultAsync(x => x.Idprestamo == id);

            if (c != null)
            {
                try
                {
                    _context.Prestamos.Remove(c);
                    await _context.SaveChangesAsync();
                    res.Exito = true;

                }
                catch (DbUpdateException)
                {
                    res.InternalServerError("Error Delete");
                }
            }
            else
            {
                res.BadRequest("Id no registrado en la BD");
            }

            return res;
        }

        private int CantidadLibrosPrestados(decimal id)
        {
            DateTime hoy = DateTime.Today;

            var libros = _context.Prestamos
                .Where(ds => ds.Idusuario == id)
                .Where(ds => ds.Fechadevolucion > hoy)
                .Count();

            return libros;
        }
    }
}
