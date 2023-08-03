using PruebaIngresoBibliotecario.Api.Aplication.Dto;
using PruebaIngresoBibliotecario.Api.Models;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Aplication.Contracts
{
    /// <summary>
    /// Interface de la capa de aplicación
    /// </summary>
    public interface IPrestamoApp
    {
        /// <summary>
        /// Crea el comando para almacenar un registro de préstamo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RequestResult<PrestamoCommandResult>> CreatePrestamo(PrestamoRequest request);
        /// <summary>
        /// Realiza la consulta de un prestamo por su id
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns></returns>
        Task<RequestResult<PrestamoQueryResult>> Get(string idPrestamo);

    }
}
