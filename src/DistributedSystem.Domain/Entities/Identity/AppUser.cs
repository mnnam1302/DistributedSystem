using DistributedSystem.Domain.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace DistributedSystem.Domain.Entities.Identity
{
    //public class AppUser : IdentityUser<Guid>
    public class AppUser : IdentityUser<Guid>, IEntity<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsDirector { get; set; }

        public bool IsHeadOfDepartment { get; set; }

        public Guid? ManagerId { get; set; }

        public Guid PositionId { get; set; }

        public int IsReceipient { get; set; }

        public string PasswordSalt { get; set; }

        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }


        protected AppUser(Guid id, string firstName, string fullName, string lastName, DateTime? dateOfBirth , string email, string passwordHash, string passwordSalt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public static AppUser Create(Guid id, string firstName, string lastName, DateTime? dateOfBirth , string email, string passwordHash, string passwordSalt)
        {
            string fullName = $"{firstName} {lastName}";

            var user = new AppUser(id, firstName, lastName, fullName, dateOfBirth, email, passwordHash, passwordSalt);

            return user;
        }
    }
}