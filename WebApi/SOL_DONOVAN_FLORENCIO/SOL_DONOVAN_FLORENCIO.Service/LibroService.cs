using Microsoft.EntityFrameworkCore;
using SOL_DONOVAN_FLORENCIO.DataAccess.Models;

namespace SOL_DONOVAN_FLORENCIO.Service
{
    public class LibroService : ILibroService
    {
        public readonly ModelContext _context;
        public LibroService(ModelContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Libro>>> GetAll()
        {
            var res = new Response<List<Libro>>();
            var list = await _context.Libros.ToListAsync();

            if (list != null)
                res.Entity = list;
            else
                res.InternalServerError("Error GetAll");

            return res;
        }

        public async Task<Response<Libro>> GetById(decimal id)
        {
            var res = new Response<Libro>();
            var Libro = await _context.Libros.FirstOrDefaultAsync(x => x.Idlibro == id);

            if (Libro != null)
                res.Entity = Libro;
            else
                res.BadRequest("El id no esta registrado en la BD");

            return res;
        }

        public async Task<Response<Libro>> Post(Libro Libro)
        {
            var res = new Response<Libro>();

            try
            {
                await _context.Libros.AddAsync(Libro);
                await _context.SaveChangesAsync();
                Libro.Idlibro = await _context.Libros.MaxAsync(u => u.Idlibro);

                res.Entity = Libro;

            }
            catch (DbUpdateException ex)
            {
                res.InternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<Response<Libro>> Put(Libro Libro)
        {
            var res = new Response<Libro>();

            _context.Entry(Libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                res.Entity = Libro;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var c = await _context.Libros.FirstOrDefaultAsync(x => x.Idlibro == Libro.Idlibro);
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
            var c = await _context.Libros.FirstOrDefaultAsync(x => x.Idlibro == id);

            if (c != null)
            {
                try
                {
                    _context.Libros.Remove(c);
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
    }
}
