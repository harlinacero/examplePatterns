using System.Linq;
using System;

namespace PruebaIngresoBibliotecario.Api.Domain.Utils
{
    public static class CalculateUtils
    {
        public static DateTime CalcularFechaRegreso(int diasPrestamo)
        {
            var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fechaDevolucion = DateTime.Now;

            for (int i = 0; i < diasPrestamo;)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
                i = !weekend.Contains(fechaDevolucion.DayOfWeek) ? ++i : i;
            }

            return fechaDevolucion;
        }
    }

}
