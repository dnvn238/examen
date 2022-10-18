using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SOL_DONOVAN_FLORENCIO.Consumer.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOL_DONOVAN_FLORENCIO.Consumer.Controllers
{
    public class PrestamoController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        List<Prestamo> _oPrestamos = new List<Prestamo>();


        public PrestamoController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reporte()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Prestamo>> GetAll()
        {
            _oPrestamos = new List<Prestamo>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7251/api/Prestamo"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oPrestamos = JsonConvert.DeserializeObject<List<Prestamo>>(apiResponse);
                }
            }

            return _oPrestamos;
        }

        [HttpPost]
        public async Task<Prestamo> Post(Prestamo prestamo)
        {
            prestamo.Fechaprestamo = DateTime.Now;
            Prestamo _oPrestamo = new Prestamo();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(prestamo),
                    Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7251/api/Prestamo", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oPrestamo = JsonConvert.DeserializeObject<Prestamo>(apiResponse);
                }
            }

            return _oPrestamo;
        }


    }
}
