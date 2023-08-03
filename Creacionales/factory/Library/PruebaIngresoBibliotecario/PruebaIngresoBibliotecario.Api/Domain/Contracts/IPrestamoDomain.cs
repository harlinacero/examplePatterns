using PruebaIngresoBibliotecario.Api.Aplication.Dto;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Api.Enums;
using PruebaIngresoBibliotecario.Api.Models;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Domain.Contracts
{
    /// <summary>
    /// Interfaz de la capa de dominio con la lógica 
    /// </summary>
    public interface IPrestamoDomain
    {
        /// <summary>
        /// Crea un nuevo préstamo
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        Task<Prestamo> CreatePrestamoAsync(Prestamo prestamo);
        /// <summary>
        /// Obtiene un préstamo por su id
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns></returns>
        Task<Prestamo> GetAsync(string idPrestamo);
    }
}
