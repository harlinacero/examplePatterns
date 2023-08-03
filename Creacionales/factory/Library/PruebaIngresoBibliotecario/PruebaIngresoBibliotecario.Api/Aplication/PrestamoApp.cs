using AutoMapper;
using PruebaIngresoBibliotecario.Api.Aplication.Contracts;
using PruebaIngresoBibliotecario.Api.Aplication.Dto;
using PruebaIngresoBibliotecario.Api.Domain.Contracts;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using PruebaIngresoBibliotecario.Api.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Aplication
{
    /// <summary>
    /// Implementación lógica sobre un préstamo
    /// </summary>
    public class PrestamoApp : IPrestamoApp
    {
        #region Fields
        /// <summary>
        /// Interfaz de la capa de dominio
        /// </summary>
        private readonly IPrestamoDomain _prestamoDomain;
        /// <summary>
        /// Mapeador de objetos
        /// </summary>
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa la instancia del objeto
        /// </summary>
        /// <param name="prestamoDomain"></param>
        /// <param name="mapper"></param>
        public PrestamoApp(IPrestamoDomain prestamoDomain, IMapper mapper)
        {
            _prestamoDomain = prestamoDomain;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Crea un préstamo, si la operación es inválida devuelve un código de error 400 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RequestResult<PrestamoCommandResult>> CreatePrestamo(PrestamoRequest request)
        {
            try
            {
                Prestamo prestamo = _mapper.Map<Prestamo>(request);
                var result = await _prestamoDomain.CreatePrestamoAsync(prestamo);
                return await RequestResult<PrestamoCommandResult>.Succesfull(_mapper.Map<PrestamoCommandResult>(result));
            }
            catch (InvalidOperationException ex)
            {
                return await RequestResult<PrestamoCommandResult>.Error(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<RequestResult<PrestamoQueryResult>> Get(string idPrestamo)
        {
            try
            {
                var result = await _prestamoDomain.GetAsync(idPrestamo);
                if (result != null)
                {
                    return await RequestResult<PrestamoQueryResult>.Succesfull(_mapper.Map<PrestamoQueryResult>(result));
                }
                return await RequestResult<PrestamoQueryResult>.Error(HttpStatusCode.NotFound, $"El prestamo con id {idPrestamo} no existe");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
