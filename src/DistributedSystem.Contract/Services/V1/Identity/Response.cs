namespace DistributedSystem.Contract.Services.V1.Identity
{
    public static class Response
    {
        public class Authenticated
        {
            public string? AccessToken { get; set; }
            public string? RefreshToken { get; set; }
            public DateTime? RefreshTokenExpiryTime { get; set; }
        }

        public sealed record UserResponse(
            string FirstName,
            string LastName,
            string FullName,
            string Email,
            DateTime? DateOfBirth,
            bool IsDirector,
            bool IsHeadOfDepartment,
            Guid? ManagerId,
            string PhoneNumber);

        //public class UserResponse
        //{
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public string FullName { get; set; }
        //    public string Email { get; set; }
        //    public DateTime? DateOfBirth { get; set; }
        //    public bool IsDirector { get; set; }
        //    public bool IsHeadOfDepartment { get; set; }
        //    public Guid? ManagerId { get; set; }
        //    public string PhoneNumber { get; set; }
        //}
    }
}