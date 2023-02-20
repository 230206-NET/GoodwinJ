namespace Models.RoleException;

[System.Serializable]
public class ArgumentRoleException : System.Exception
{
    public ArgumentRoleException() { }
    public ArgumentRoleException(string message) : base(message) { }
    public ArgumentRoleException(string message, System.Exception inner) : base(message, inner) { }
    protected ArgumentRoleException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}