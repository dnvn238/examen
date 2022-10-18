using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SOL_DONOVAN_FLORENCIO.Consumer.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SOL_DONOVAN_FLORENCIO.Consumer.Controllers
{
    public class LibroController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        List<Libro> _oLibros = new List<Libro>();


        public LibroController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Libro>> GetAll()
        {
            _oLibros = new List<Libro>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7251/api/Libro"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oLibros = JsonConvert.DeserializeObject<List<Libro>>(apiResponse);
                }
            }

            return _oLibros;
        }
    }
}
