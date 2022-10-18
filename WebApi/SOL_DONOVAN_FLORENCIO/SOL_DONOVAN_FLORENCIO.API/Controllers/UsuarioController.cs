using Microsoft.AspNetCore.Mvc;
using SOL_DONOVAN_FLORENCIO.DataAccess.Models;
using SOL_DONOVAN_FLORENCIO.Service;

namespace SOL_DONOVAN_FLORENCIO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _servicio;

        public UsuarioController(IUsuarioService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            var result = await _servicio.GetAll();

            if (result.Entity != null)
                return result.Entity.ToList();
            else
                return StatusCode(result.Status, result.Error);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(decimal id)
        {
            var result = await _servicio.GetById(id);

            if (result.Entity != null)
                return result.Entity;
            else
                return StatusCode(result.Status, result.Error);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario c)
        {
            var result = await _servicio.Post(c);

            if (result.Entity != null)
                return result.Entity;
            else
                return StatusCode(result.Status, result.Error);
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> Put(Usuario c)
        {
            var result = await _servicio.Put(c);

            if (result.Entity != null)
                return result.Entity;
            else
                return StatusCode(result.Status, result.Error);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(decimal id)
        {
            var result = await _servicio.Delete(id);

            if (result.Exito)
                return true;
            else
                return StatusCode(result.Status, result.Error);
        }
    }
}
