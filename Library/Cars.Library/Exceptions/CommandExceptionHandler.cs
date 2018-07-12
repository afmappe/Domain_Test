using Cars.Library.Infrastructure.Common;
using System;
using System.Runtime.ExceptionServices;

namespace Cars.Library.Exceptions
{
    /// <summary>
    /// Manejador de excepciones para comando
    /// </summary>
    public static class CommandExceptionHandler
    {
        /// <summary>
        /// Seria-liza los parámetros de la solicitud y los agrega a la excepción
        /// </summary>
        /// <typeparam name="TRequest">Tipo genérico de solicitud</typeparam>
        /// <param name="ex">Excepción</param>
        /// <param name="request">Solicitud</param>
        public static void Handle<TRequest>(Exception ex, TRequest request)
        {
            if (request != null && !ex.Data.Contains("request"))
            {
                ex.Data.Add("request", JsonSerializer.Serialize(request));
            }
            ExceptionDispatchInfo.Capture(ex).Throw();
        }
    }
}