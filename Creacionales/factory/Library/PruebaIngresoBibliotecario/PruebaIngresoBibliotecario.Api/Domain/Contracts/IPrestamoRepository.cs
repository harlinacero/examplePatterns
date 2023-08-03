using PruebaIngresoBibliotecario.Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Domain.Contracts
{
    /// <summary>
    /// Interfaz de la capa de repositorio
    /// </summary>
    public interface IPrestamoRepository
    {
        /// <summary>
        /// Obtiene un préstamo por su id
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns></returns>
        Task<Prestamo> GetPrestamoByIdAsync(string idPrestamo);
        /// <summary>
        /// Obtiene los préstamos por usuario
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Task<IEnumerable<Prestamo>> GetPrestamoByUserAsync(string userid);
        /// <summary>
        /// Almacena un préstamo en el repositorio
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        Task<Prestamo> SavePrestamo(Prestamo prestamo);
    }
}
