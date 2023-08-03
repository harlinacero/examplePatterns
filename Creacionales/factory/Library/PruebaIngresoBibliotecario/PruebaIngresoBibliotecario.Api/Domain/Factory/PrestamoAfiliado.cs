using PruebaIngresoBibliotecario.Api.Domain.Contracts;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Api.Domain.Utils;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Domain.Factory
{
    public class PrestamoAfiliado : PrestamoBase, IPrestamoFactory
    {
        public PrestamoAfiliado(IPrestamoRepository prestamoRepository) : base(prestamoRepository)
        {
        }

        public async Task<Prestamo> CrearPrestamo(Prestamo prestamo)
        {
            prestamo.FechaMaximaDevolucion = CalculateUtils.CalcularFechaRegreso(10);
            return await _prestamoRepository.SavePrestamo(prestamo);
        }
    }
}
