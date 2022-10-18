using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SOL_DONOVAN_FLORENCIO.Consumer.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SOL_DONOVAN_FLORENCIO.Consumer.Controllers
{
    public class UsuarioController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        List<Usuario> _oUsuarios = new List<Usuario>();


        public UsuarioController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Usuario>> GetAll()
        {
            _oUsuarios = new List<Usuario>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7251/api/Usuario"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(apiResponse);
                }
            }

            return _oUsuarios;
        }

    }
}
