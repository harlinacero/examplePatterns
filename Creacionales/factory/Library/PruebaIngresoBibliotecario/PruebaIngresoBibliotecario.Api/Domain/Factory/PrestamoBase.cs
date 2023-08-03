using PruebaIngresoBibliotecario.Api.Domain.Contracts;

namespace PruebaIngresoBibliotecario.Api.Domain.Factory
{
    public abstract class PrestamoBase
    {
        #region Fields
        /// <summary>
        /// Objeto del repositorio
        /// </summary>
        protected readonly IPrestamoRepository _prestamoRepository;
        #endregion

        #region Constructor
        public PrestamoBase(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        #endregion
    }
}
