using PruebaIngresoBibliotecario.Api.Domain.Contracts;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Api.Domain.Utils;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Domain.Factory
{
    public class PrestamoEmpleado : PrestamoBase, IPrestamoFactory
    {
        public PrestamoEmpleado(IPrestamoRepository prestamoRepository) : base(prestamoRepository)
        {
        }

        public async Task<Prestamo> CrearPrestamo(Prestamo prestamo)
        {
            prestamo.FechaMaximaDevolucion = CalculateUtils.CalcularFechaRegreso(8);
            return await _prestamoRepository.SavePrestamo(prestamo);
        }
    }
}
