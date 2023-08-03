using System;

namespace PruebaIngresoBibliotecario.Api.Aplication.Dto
{
    /// <summary>
    /// DTO con la respuesta al almacenar un préstamo
    /// </summary>
    public class PrestamoCommandResult
    {
        public Guid Id { get; set; }
        public Guid Isbn { get; set; }
        public string TipoUsuario { get; set; }
        public string IdentificacionUsuario { get; set; }
        public string FechaMaximaDevolucion { get; set; }
    }
}
