using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cars.Library.Exceptions
{
    [Serializable]
    public class GeneralException : Exception
    {
        /// <summary>
        ///
        /// </summary>
        public GeneralException()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        public GeneralException(string message) : base(message)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public GeneralException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected GeneralException(SerializationInfo info, StreamingContext context)
              : base(info, context)
        {
            ResourceReferenceProperty = info.GetString("ResourceReferenceProperty");
        }

        public string ResourceReferenceProperty { get; set; }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            info.AddValue("ResourceReferenceProperty", ResourceReferenceProperty);
            base.GetObjectData(info, context);
        }
    }
}