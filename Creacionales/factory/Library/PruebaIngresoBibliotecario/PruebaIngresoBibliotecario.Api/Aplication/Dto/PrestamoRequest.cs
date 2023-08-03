using PruebaIngresoBibliotecario.Api.Enums;
using System;

namespace PruebaIngresoBibliotecario.Api.Aplication.Dto
{
    /// <summary>
    /// DTO para la solicitud de un préstamo
    /// </summary>
    public class PrestamoRequest
    {
        public TipoUsuarioPrestamo TipoUsuario { get; set; }
        public string IdentificacionUsuario { get; set; }
        public Guid Isbn { get; set; }
    }
}
