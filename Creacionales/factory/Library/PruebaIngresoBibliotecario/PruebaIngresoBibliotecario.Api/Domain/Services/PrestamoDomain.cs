using PruebaIngresoBibliotecario.Api.Domain.Contracts;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Api.Domain.Factory;
using PruebaIngresoBibliotecario.Api.Enums;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Domain.Services
{
    /// <summary>
    /// Implementación de la capa de dominio
    /// </summary>
    public class PrestamoDomain : IPrestamoDomain
    {
        #region Fields
        /// <summary>
        /// Objeto del repositorio
        /// </summary>
        private readonly IPrestamoRepository _prestamoRepository;
        #endregion
        #region Constructor
        public PrestamoDomain(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Obtiene un préstamo por su id
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns></returns>
        public async Task<Prestamo> GetAsync(string idPrestamo)
        {
            return await _prestamoRepository.GetPrestamoByIdAsync(idPrestamo);
        }

        /// <summary>
        /// Almacena un préstamo en el repositorio
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        public async Task<Prestamo> CreatePrestamoAsync(Prestamo prestamo)
        {
            IPrestamoFactory prestamoHandler = prestamo.TipoUsuario switch
            {
                TipoUsuarioPrestamo.INVITADO => new PrestamoInvitado(_prestamoRepository),
                TipoUsuarioPrestamo.AFILIADO => new PrestamoAfiliado(_prestamoRepository),
                TipoUsuarioPrestamo.EMPLEADO => new PrestamoEmpleado(_prestamoRepository),
                _ => throw new InvalidOperationException("El usuario no es válido"),
            };
            return await prestamoHandler.CrearPrestamo(prestamo);
        }
        #endregion

    }
}
