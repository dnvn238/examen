using SOL_DONOVAN_FLORENCIO.DataAccess.Models;

namespace SOL_DONOVAN_FLORENCIO.Service
{
    public interface IPrestamoService
    {
        Task<Response<IEnumerable<Prestamo>>> GetAll();
        Task<Response<Prestamo>> GetById(decimal id);
        Task<Response<Prestamo>> Post(Prestamo categoria);
        Task<Response<Prestamo>> Put(Prestamo categoria);
        Task<Response<bool>> Delete(decimal id);
    }
}
