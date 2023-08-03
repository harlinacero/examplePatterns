using System.Net;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Models
{
    public class RequestResult<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        /// <summary>
        /// Crea una respuesta exitosa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static async Task<RequestResult<T>> Succesfull(T entity)
        {
            return new RequestResult<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Result = entity
            };
        }

        /// <summary>
        /// Crea una respuesta con error
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<RequestResult<T>> Error(HttpStatusCode statusCode, string message)
        {
            return new RequestResult<T>()
            {
                StatusCode = statusCode,
                Message = message
            };
        }

    }
}
