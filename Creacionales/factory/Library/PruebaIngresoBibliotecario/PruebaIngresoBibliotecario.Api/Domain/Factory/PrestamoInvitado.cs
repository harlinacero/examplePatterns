using PruebaIngresoBibliotecario.Api.Domain.Contracts;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Api.Domain.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Domain.Factory
{
    public class PrestamoInvitado : PrestamoBase, IPrestamoFactory
    {
        public PrestamoInvitado(IPrestamoRepository prestamoRepository) : base(prestamoRepository)
        {
        }

        public async Task<Prestamo> CrearPrestamo(Prestamo prestamo)
        {
            var prestamosByUser = await _prestamoRepository.GetPrestamoByUserAsync(prestamo.IdentificacionUsuario);
            if (prestamosByUser.Count() > 0)
            {
                string message = $"El usuario con identificacion {prestamo.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo";

                throw new InvalidOperationException(message);
            }
            prestamo.FechaMaximaDevolucion = CalculateUtils.CalcularFechaRegreso(7);
            return await _prestamoRepository.SavePrestamo(prestamo);
        }
    }
}
