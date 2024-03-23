namespace DistributedSystem.Domain.Exceptions;

public static class IdentityException
{
    #region =========== Token ================
    public class TokenException : DomainException
    {
        public TokenException(string message)
            : base("Token Exception", message)
        {
        }
    }

    #endregion =========== Token ================


    #region =========== AppUsers ================

    public class UserExistsException : DomainException
    {
        public UserExistsException(string message) 
            : base("User Exception", message)
        {
        }
    }

    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid userId)
            : base($"The user with Id {userId} was not found.")
        {
        }
    }

    public class UserNotFoundByEmailException : NotFoundException
    {
        public UserNotFoundByEmailException(string email)
            : base($"The user with Email {email} was not found.")
        {
        }
    }

    #endregion =========== AppUsers ================

    #region =========== AppRoles ================

    public class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException(Guid roleId)
            : base($"The role with Id {roleId} was not found.")
        {
        }
    }

    #endregion =========== AppRoles ================
}
