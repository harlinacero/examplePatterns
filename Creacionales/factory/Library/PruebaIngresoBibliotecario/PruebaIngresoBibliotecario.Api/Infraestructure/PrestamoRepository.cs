using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Api.Domain.Contracts;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Infraestructure
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly PersistenceContext _context;
        /// <summary>
        /// Constructor con la instancia del contexto
        /// </summary>
        /// <param name="context"></param>
        public PrestamoRepository(PersistenceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene un préstamo por el id
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns></returns>
        public async Task<Prestamo> GetPrestamoByIdAsync(string idPrestamo) =>
            await _context.Prestamos.FirstOrDefaultAsync(d => d.Id.Equals(Guid.Parse(idPrestamo)));

        /// <summary>
        /// Obtiene los préstamos de un usuario
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Prestamo>> GetPrestamoByUserAsync(string userid) =>
            await _context.Prestamos.Where(d => d.IdentificacionUsuario.Equals(userid)).ToListAsync();

        /// <summary>
        /// Almacena un préstamo
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        public async Task<Prestamo> SavePrestamo(Prestamo prestamo)
        {
            var newPrestamo = await _context.Prestamos.AddAsync(prestamo);
            await _context.SaveChangesAsync();
            return newPrestamo.Entity;
        }
    }
}
