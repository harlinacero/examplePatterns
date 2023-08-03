using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Api.Aplication;
using PruebaIngresoBibliotecario.Api.Aplication.Contracts;
using PruebaIngresoBibliotecario.Api.Aplication.Dto;
using System.Net;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoApp _prestamoApp;

        public PrestamoController(IPrestamoApp prestamoApp)
        {
            _prestamoApp = prestamoApp;
        }

        /// <summary>
        /// Crea un préstamo
        /// </summary>
        /// <param name="resquest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Prestamo(PrestamoRequest resquest)
        {
            var response = _prestamoApp.CreatePrestamo(resquest).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Result);
            }
            var error = new { mensaje = response.Message };
            return StatusCode(response.StatusCode.GetHashCode(),error );
        }

        /// <summary>
        /// Obtiene un préstamo por su Id
        /// </summary>
        /// <param name="prestamoId"></param>
        /// <returns></returns>
        [HttpGet("{prestamoId}")]
        public ActionResult Prestamo(string prestamoId)
        {
            var response = _prestamoApp.Get(prestamoId).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Result);
            }
            var error = new { mensaje = response.Message };
            return StatusCode(response.StatusCode.GetHashCode(), error);
        }

    }
}
