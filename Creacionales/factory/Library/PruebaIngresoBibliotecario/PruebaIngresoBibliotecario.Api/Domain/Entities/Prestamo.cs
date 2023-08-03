using PruebaIngresoBibliotecario.Api.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaIngresoBibliotecario.Api.Domain.Entities
{
    /// <summary>
    /// Entidad de dominio préstamo
    /// </summary>
    public class Prestamo
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Isbn { get; set; }
        public TipoUsuarioPrestamo TipoUsuario { get; set; }
        public string IdentificacionUsuario { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
