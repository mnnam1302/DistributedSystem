namespace DistributedSystem.Domain.Exceptions
{
    public static class IdentityException
    {
        public class TokenException : DomainException
        {
            public TokenException(string message)
                : base("Token Exception", message)
            {
            }
        }

        public class UserExistsException : DomainException
        {
            public UserExistsException(string message) 
                : base("User Exception", message)
            {
            }
        }
    }
}