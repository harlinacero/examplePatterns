using System;
using System.Text.Json.Serialization;

namespace PruebaIngresoBibliotecario.Api.Aplication.Dto
{
    /// <summary>
    /// DTO con la cosulta de un préstamo
    /// </summary>
    public class PrestamoQueryResult
    {
        [JsonPropertyName("id")]
        public Guid IdPrestamoLibro { get; set; }
        [JsonPropertyName("identificacionUsuario")]
        public string IdUsuarioPrestamoLibro { get; set; }
        [JsonPropertyName("isbn")]
        public Guid IsbnLibroPrestamo { get; set; }
        [JsonPropertyName("tipoUsuario")]
        public int TipoUsuarioServicioBibliteca { get; set; }
        [JsonPropertyName("fechaMaximaDevolucion")]
        public DateTime FechaDevolucionPrestamoLibro { get; set; }
    }
}
