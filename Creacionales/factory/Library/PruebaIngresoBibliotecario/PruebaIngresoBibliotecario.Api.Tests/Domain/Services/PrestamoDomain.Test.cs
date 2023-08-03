using Api.Test;
using Moq;
using PruebaIngresoBibliotecario.Api.Aplication.Dto;
using PruebaIngresoBibliotecario.Api.Aplication;
using PruebaIngresoBibliotecario.Api.Domain.Contracts;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Api.Domain.Services;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace PruebaIngresoBibliotecario.Api.Tests.Domain.Services
{
    public class PrestamoDomainTest : IntegrationTestBuilder
    {
        private readonly Mock<IPrestamoRepository> _prestamoRepositoryMock;

        public PrestamoDomainTest()
        {
            _prestamoRepositoryMock = new Mock<IPrestamoRepository>();
        }

        [Fact]
        public async Task GetPrestamoReturnPrestamo()
        {
            // Arrange
            string identificacionUsuario = "1234566";
            Guid id = Guid.NewGuid();
            Guid Isbn = Guid.NewGuid();
            var fechaMaximaDevolucion = CalcularFechaEntrega(TipoUsuarioPrestamo.AFILIADO);

            var prestamo = new Prestamo
            {
                Id = id,
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                FechaMaximaDevolucion = fechaMaximaDevolucion,
                TipoUsuario = It.IsAny<Enums.TipoUsuarioPrestamo>()
            };

            _prestamoRepositoryMock.Setup(repo => repo.GetPrestamoByIdAsync(id.ToString()))
                .ReturnsAsync(prestamo);

            var prestamoDomain = new PrestamoDomain(_prestamoRepositoryMock.Object);

            // Act
            var result = await prestamoDomain.GetAsync(id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(prestamo, result);
        }

        [Fact]
        public async Task GetPrestamoReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _prestamoRepositoryMock.Setup(repo => repo.GetPrestamoByIdAsync(id.ToString()))
                .ReturnsAsync(It.IsAny<Prestamo>());

            var prestamoDomain = new PrestamoDomain(_prestamoRepositoryMock.Object);

            // Act
            var result = await prestamoDomain.GetAsync(id.ToString());

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(Enums.TipoUsuarioPrestamo.AFILIADO)]
        [InlineData(Enums.TipoUsuarioPrestamo.INVITADO)]
        [InlineData(Enums.TipoUsuarioPrestamo.EMPLEADO)]
        public async Task CreatePrestamoByUserTypeReturnOk(Enums.TipoUsuarioPrestamo tipoUsuario)
        {
            // Arrange
            string identificacionUsuario = "1234566";
            Guid id = Guid.NewGuid();
            Guid Isbn = Guid.NewGuid();
            var fechaMaximaDevolucion = CalcularFechaEntrega((TipoUsuarioPrestamo)tipoUsuario);

            var prestamo = new Prestamo
            {
                Id = id,
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                FechaMaximaDevolucion = fechaMaximaDevolucion,
                TipoUsuario = tipoUsuario
            };


            _prestamoRepositoryMock.Setup(domain => domain.SavePrestamo(prestamo))
                .ReturnsAsync(prestamo);

            var prestamoService = new PrestamoDomain(_prestamoRepositoryMock.Object);

            // Act
            var responsePrestamo = await prestamoService.CreatePrestamoAsync(prestamo);

            // Assert
            Assert.NotNull(responsePrestamo);
            Assert.Equal(prestamo, responsePrestamo);
            Assert.Equal(prestamo.FechaMaximaDevolucion, responsePrestamo.FechaMaximaDevolucion);
        }

        [Fact]
        public async Task CreatePrestamoUserTypeInvitadoReturnHasPrestamo()
        {
            // Arrange
            string identificacionUsuario = "1234566";
            Guid id = Guid.NewGuid();
            Guid Isbn = Guid.NewGuid();
            var fechaMaximaDevolucion = It.IsAny<DateTime>();
            string errorMessage = $"El usuario con identificacion {identificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo";
            
            var prestamo = new Prestamo
            {
                Id = id,
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                FechaMaximaDevolucion = fechaMaximaDevolucion,
                TipoUsuario = Enums.TipoUsuarioPrestamo.INVITADO
            };

            _prestamoRepositoryMock.Setup(domain => domain.GetPrestamoByUserAsync(identificacionUsuario))
                .ReturnsAsync(new List<Prestamo> { prestamo });

            var prestamoService = new PrestamoDomain(_prestamoRepositoryMock.Object);

            // Act & Assert
            var responsePrestamo = await Assert.ThrowsAsync<InvalidOperationException>(async () => 
                await prestamoService.CreatePrestamoAsync(prestamo));

            Assert.NotNull(responsePrestamo);
            Assert.IsType<InvalidOperationException>(responsePrestamo);
            Assert.Equal(errorMessage, responsePrestamo.Message);
        }

        [Fact]
        public async Task CreatePrestamoInvalidUser()
        {
            // Arrange          
            var prestamo = new Prestamo
            {
                TipoUsuario = (Enums.TipoUsuarioPrestamo)5
            };
            string errorMessage = $"El usuario no es válido";


            var prestamoService = new PrestamoDomain(_prestamoRepositoryMock.Object);

            // Act & Assert
            var responsePrestamo = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await prestamoService.CreatePrestamoAsync(prestamo));

            Assert.NotNull(responsePrestamo);
            Assert.IsType<InvalidOperationException>(responsePrestamo);
            Assert.Equal(errorMessage, responsePrestamo.Message);
        }
    }
}
