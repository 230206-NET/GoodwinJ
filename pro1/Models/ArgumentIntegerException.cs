namespace Models.IntegerException;

[System.Serializable]
public class ArgumentIntegerException : System.Exception
{
    public ArgumentIntegerException() { }
    public ArgumentIntegerException(string message) : base(message) { }
    public ArgumentIntegerException(string message, System.Exception inner) : base(message, inner) { }
    protected ArgumentIntegerException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}