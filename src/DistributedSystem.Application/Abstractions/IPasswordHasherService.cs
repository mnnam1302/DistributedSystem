namespace DistributedSystem.Application.Abstractions
{
    public interface IPasswordHasherService
    {
        string HashPassword(string password, string salt);

        bool VerifyPassword(string plaintextPassword, string cipertextPassword, string salt);

        string GenerateSalt();
    }
}