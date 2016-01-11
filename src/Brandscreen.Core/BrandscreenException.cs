using System;
using System.Runtime.Serialization;

namespace Brandscreen.Core
{
    [Serializable]
    public class BrandscreenException : ApplicationException
    {
        public BrandscreenException(string message) : base(message)
        {
        }

        public BrandscreenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BrandscreenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}