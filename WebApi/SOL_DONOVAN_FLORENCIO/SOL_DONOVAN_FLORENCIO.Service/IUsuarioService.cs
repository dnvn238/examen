using SOL_DONOVAN_FLORENCIO.DataAccess.Models;

namespace SOL_DONOVAN_FLORENCIO.Service
{
    public interface IUsuarioService
    {
        Task<Response<List<Usuario>>> GetAll();
        Task<Response<Usuario>> GetById(decimal id);
        Task<Response<Usuario>> Post(Usuario categoria);
        Task<Response<Usuario>> Put(Usuario categoria);
        Task<Response<bool>> Delete(decimal id);
    }
}
