using System.Runtime.Serialization;

namespace Laborator3.Model.Exceptions;

[Serializable ]
public class InvalidQuantityException : Exception
{
    public InvalidQuantityException() { }
    public InvalidQuantityException(string? message) : base(message) { }
    public InvalidQuantityException(string? message, Exception? innerException) : base(message, innerException) { }
    protected InvalidQuantityException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
