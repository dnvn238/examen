using Microsoft.EntityFrameworkCore;
using SOL_DONOVAN_FLORENCIO.DataAccess.Models;

namespace SOL_DONOVAN_FLORENCIO.Service
{
    public class UsuarioService : IUsuarioService
    {
        public readonly ModelContext _context;
        public UsuarioService(ModelContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Usuario>>> GetAll()
        {
            var res = new Response<List<Usuario>>();
            var list = await _context.Usuarios.ToListAsync();
            //var list = await _context.Usuarios
            //   .Include("Prestamo")
            //   .ToListAsync();



            if (list != null)
                res.Entity = list;
            else
                res.InternalServerError("Error GetAll");

            return res;
        }

        public async Task<Response<Usuario>> GetById(decimal id)
        {
            var res = new Response<Usuario>();
            var Usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Idusuario == id);

            if (Usuario != null)
                res.Entity = Usuario;
            else
                res.BadRequest("El id no esta registrado en la BD");

            return res;
        }

        public async Task<Response<Usuario>> Post(Usuario Usuario)
        {
            var res = new Response<Usuario>();

            try
            {
                await _context.Usuarios.AddAsync(Usuario);
                await _context.SaveChangesAsync();
                Usuario.Idusuario = await _context.Usuarios.MaxAsync(u => u.Idusuario);

                res.Entity = Usuario;

            }
            catch (DbUpdateException ex)
            {
                res.InternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<Response<Usuario>> Put(Usuario Usuario)
        {
            var res = new Response<Usuario>();

            _context.Entry(Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                res.Entity = Usuario;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var c = await _context.Usuarios.FirstOrDefaultAsync(x => x.Idusuario == Usuario.Idusuario);
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
            var c = await _context.Usuarios.FirstOrDefaultAsync(x => x.Idusuario == id);

            if (c != null)
            {
                try
                {
                    _context.Usuarios.Remove(c);
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
