using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Api.Enums;
using PruebaIngresoBibliotecario.Api.Infraestructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Domain.Factory
{
    public interface IPrestamoFactory
    {
        Task<Prestamo> CrearPrestamo(Prestamo prestamo);
    }
}
