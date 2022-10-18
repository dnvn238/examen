using Microsoft.AspNetCore.Mvc;
using SOL_DONOVAN_FLORENCIO.DataAccess.Models;
using SOL_DONOVAN_FLORENCIO.Service;

namespace SOL_DONOVAN_FLORENCIO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _servicio;

        public PrestamoController(IPrestamoService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Prestamo>>> GetAll()
        {
            var result = await _servicio.GetAll();

            if (result.Entity != null)
                return result.Entity.ToList();
            else
                return StatusCode(result.Status, result.Error);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetById(decimal id)
        {
            var result = await _servicio.GetById(id);

            if (result.Entity != null)
                return result.Entity;
            else
                return StatusCode(result.Status, result.Error);
        }

        [HttpPost]
        public async Task<ActionResult<Prestamo>> Post(Prestamo c)
        {
            var result = await _servicio.Post(c);

            if (result.Entity != null)
                return result.Entity;
              else
                return StatusCode(result.Status, result.Error);
        }

        [HttpPut]
        public async Task<ActionResult<Prestamo>> Put(Prestamo c)
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
