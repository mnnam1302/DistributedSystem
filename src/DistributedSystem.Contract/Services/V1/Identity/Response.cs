namespace DistributedSystem.Contract.Services.V1.Identity
{
    public static class Response
    {
        public sealed class Authenticated
        {
            public string? AccessToken { get; set; }
            public string? RefreshToken { get; set; }
            public DateTime? RefreshTokenExpiryTime { get; set; }
        }

        public sealed record UserResponse
        {
            public Guid Id { get; init; }
            public string FirstName { get; init; }
            public string LastName { get; init; }
            public string FullName { get; init; }
            public string Email { get; init; }
            public DateTime? DateOfBirth { get; init; }
            public bool IsDirector { get; init; }
            public bool IsHeadOfDepartment { get; init; }
            public Guid? ManagerId { get; init; }
            public string PhoneNumber { get; init; }
        }

        public sealed record UserRoleResponse
        {
            public Guid Id { get; init; }
            //public string FullName { get; init; }
            public string Name { get; init; }
        }

        //public sealed record UserResponse(
        //    string FirstName,
        //    string LastName,
        //    string FullName,
        //    string Email,
        //    DateTime? DateOfBirth,
        //    bool IsDirector,
        //    bool IsHeadOfDepartment,
        //    Guid? ManagerId,
        //    string PhoneNumber);

        //public sealed class UserResponse
        //{
        //    public UserResponse()
        //    {
        //    }

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