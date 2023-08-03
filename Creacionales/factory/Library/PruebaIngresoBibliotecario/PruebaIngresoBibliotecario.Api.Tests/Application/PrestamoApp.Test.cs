using Api.Test;
using AutoMapper;
using Moq;
using PruebaIngresoBibliotecario.Api.Aplication;
using PruebaIngresoBibliotecario.Api.Aplication.Dto;
using PruebaIngresoBibliotecario.Api.Domain.Contracts;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PruebaIngresoBibliotecario.Api.Tests.Application
{
    public class PrestamoAppTest : IntegrationTestBuilder
    {
        private readonly Mock<IPrestamoDomain> _prestamoDomainMock;
        private readonly Mock<IMapper> _mapperMock;

        public PrestamoAppTest()
        {
            _mapperMock = new Mock<IMapper>();
            _prestamoDomainMock = new Mock<IPrestamoDomain>();
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

            var request = new PrestamoRequest
            {
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                TipoUsuario = tipoUsuario
            };

            var prestamo = new Prestamo
            {
                Id = id,
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                FechaMaximaDevolucion = fechaMaximaDevolucion,
                TipoUsuario = tipoUsuario
            };

            var prestamoCommandResult = new PrestamoCommandResult
            {
                Id = id,
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                FechaMaximaDevolucion = fechaMaximaDevolucion.ToShortDateString(),
                TipoUsuario = tipoUsuario.ToString()
            };

            _mapperMock.Setup(mapper => mapper.Map<Prestamo>(request))
           .Returns(prestamo);
            _mapperMock.Setup(mapper => mapper.Map<PrestamoCommandResult>(It.IsAny<Prestamo>()))
            .Returns(prestamoCommandResult);

            _prestamoDomainMock.Setup(domain => domain.CreatePrestamoAsync(prestamo))
                .ReturnsAsync(prestamo);

            var prestamoService = new PrestamoApp(_prestamoDomainMock.Object, _mapperMock.Object);

            // Act
            var requestResult = await prestamoService.CreatePrestamo(request);

            // Assert
            Assert.NotNull(requestResult);
            Assert.Equal(System.Net.HttpStatusCode.OK, requestResult.StatusCode);
            Assert.Equal(prestamoCommandResult, requestResult.Result);
        }

        [Fact]
        public async Task CreatePrestamoInvalidRequestReturnsErrorResult()
        {
            // Arrange
            var request = new PrestamoRequest { };
            var errorMessage = "Operation is not valid due to the current state of the object.";

            _mapperMock.Setup(mapper => mapper.Map<Prestamo>(request))
                .Throws<InvalidOperationException>();

            var prestamoService = new PrestamoApp(_prestamoDomainMock.Object, _mapperMock.Object);

            // Act
            var result = await prestamoService.CreatePrestamo(request);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Result);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal(errorMessage, result.Message);
        }

        [Fact]
        public async Task CreatePrestamoUserInvalidErrorResult()
        {
            // Arrange
            var errorMessage = "\"El usuario no es válido\"";
            string identificacionUsuario = "1234566";
            Guid id = Guid.NewGuid();
            Guid Isbn = Guid.NewGuid();
            var fechaMaximaDevolucion = CalcularFechaEntrega(TipoUsuarioPrestamo.AFILIADO);
            var tipoUsuario = (Enums.TipoUsuarioPrestamo)5;
            var request = new PrestamoRequest
            {
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                TipoUsuario = tipoUsuario
            };

            var prestamo = new Prestamo
            {
                Id = id,
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                FechaMaximaDevolucion = fechaMaximaDevolucion,
                TipoUsuario = tipoUsuario
            };


            _mapperMock.Setup(mapper => mapper.Map<Prestamo>(request))
           .Returns(prestamo);

            _prestamoDomainMock.Setup(domain => domain.CreatePrestamoAsync(prestamo))
                .ThrowsAsync(new InvalidOperationException(errorMessage));

            var prestamoService = new PrestamoApp(_prestamoDomainMock.Object, _mapperMock.Object);

            // Act
            var result = await prestamoService.CreatePrestamo(request);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Result);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal(errorMessage, result.Message);
        }

        [Fact]
        public async Task CreatePrestamoUserInvitadoHasPrestamoErrorResult()
        {
            // Arrange
            string identificacionUsuario = "1234566";
            var errorMessage = $"El usuario con identificacion {identificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo";
            Guid id = Guid.NewGuid();
            Guid Isbn = Guid.NewGuid();
            var fechaMaximaDevolucion = CalcularFechaEntrega(TipoUsuarioPrestamo.AFILIADO);
            var tipoUsuario = Enums.TipoUsuarioPrestamo.INVITADO;
            var request = new PrestamoRequest
            {
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                TipoUsuario = tipoUsuario
            };

            var prestamo = new Prestamo
            {
                Id = id,
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                FechaMaximaDevolucion = fechaMaximaDevolucion,
                TipoUsuario = tipoUsuario
            };


            _mapperMock.Setup(mapper => mapper.Map<Prestamo>(request))
           .Returns(prestamo);

            _prestamoDomainMock.Setup(domain => domain.CreatePrestamoAsync(prestamo))
                .ThrowsAsync(new InvalidOperationException(errorMessage));

            var prestamoService = new PrestamoApp(_prestamoDomainMock.Object, _mapperMock.Object);

            // Act
            var result = await prestamoService.CreatePrestamo(request);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Result);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal(errorMessage, result.Message);
        }

        [Theory]
        [InlineData(Enums.TipoUsuarioPrestamo.AFILIADO)]
        [InlineData(Enums.TipoUsuarioPrestamo.INVITADO)]
        [InlineData(Enums.TipoUsuarioPrestamo.EMPLEADO)]
        public async Task GetPrestamoReturnOk(Enums.TipoUsuarioPrestamo tipoUsuario)
        {
            // Arrange
            string identificacionUsuario = "1234566";
            Guid idPrestamo = Guid.NewGuid();
            Guid Isbn = Guid.NewGuid();
            var fechaMaximaDevolucion = CalcularFechaEntrega(TipoUsuarioPrestamo.AFILIADO);

            var prestamo = new Prestamo
            {
                Id = idPrestamo,
                IdentificacionUsuario = identificacionUsuario,
                Isbn = Isbn,
                FechaMaximaDevolucion = fechaMaximaDevolucion,
                TipoUsuario = tipoUsuario
            };

            PrestamoQueryResult prestamoQueryResult = new PrestamoQueryResult
            {
                FechaDevolucionPrestamoLibro = fechaMaximaDevolucion,
                IdPrestamoLibro = idPrestamo,
                IdUsuarioPrestamoLibro = identificacionUsuario,
                IsbnLibroPrestamo = Isbn,
                TipoUsuarioServicioBibliteca = tipoUsuario.GetHashCode()
            };


            _mapperMock.Setup(mapper => mapper.Map<PrestamoQueryResult>(prestamo))
            .Returns(prestamoQueryResult);
            _prestamoDomainMock.Setup(domain => domain.GetAsync(idPrestamo.ToString()))
                .ReturnsAsync(prestamo);

            var prestamoService = new PrestamoApp(_prestamoDomainMock.Object, _mapperMock.Object);

            // Act
            var result = await prestamoService.Get(idPrestamo.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(prestamoQueryResult, result.Result);
        }

        [Fact]
        public async Task GetPrestamoReturnNotFound()
        {
            //Arragnge
            Guid idPrestamo = Guid.NewGuid();
            string errorMessage = $"El prestamo con id {idPrestamo} no existe";

            _prestamoDomainMock.Setup(domain => domain.GetAsync(idPrestamo.ToString()))
                .ReturnsAsync(It.IsAny<Prestamo>());

            var prestamoService = new PrestamoApp(_prestamoDomainMock.Object, _mapperMock.Object);

            // Act
            var result = await prestamoService.Get(idPrestamo.ToString());

            // Assert
            // Assert
            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
            Assert.Equal(errorMessage, result.Message);
        }
    }
}
