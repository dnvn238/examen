using SOL_DONOVAN_FLORENCIO.DataAccess.Models;

namespace SOL_DONOVAN_FLORENCIO.Service
{
    public interface ILibroService
    {
        Task<Response<List<Libro>>> GetAll();
        Task<Response<Libro>> GetById(decimal id);
        Task<Response<Libro>> Post(Libro categoria);
        Task<Response<Libro>> Put(Libro categoria);
        Task<Response<bool>> Delete(decimal id);
    }
}
