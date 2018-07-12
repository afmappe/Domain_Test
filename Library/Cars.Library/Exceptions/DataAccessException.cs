using System;
using System.Runtime.Serialization;

namespace Cars.Library.Exceptions
{
    /// <summary>
    ///
    /// </summary>
    public enum DataExceptionCode
    {
        /// <summary>
        ///
        /// </summary>
        DuplicateObject,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public class DataAccessException : GeneralException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code">Código de la excepción</param>
        public DataAccessException(DataExceptionCode code)
            : this(code, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code">Código de la excepción</param>
        /// <param name="innerException">Excepción interna</param>
        public DataAccessException(DataExceptionCode code, Exception innerException)
            : base(code.ToString(), innerException)
        {
            Code = code;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DataAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Código del error
        /// </summary>
        public DataExceptionCode Code { get; private set; }
    }
}