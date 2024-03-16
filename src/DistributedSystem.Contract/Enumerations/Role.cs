using Ardalis.SmartEnum;

namespace DistributedSystem.Contract.Enumerations
{
    public sealed class Role : SmartEnum<Role>
    {
        public Role(string name, int value) 
            : base(name, value)
        { }

        public static readonly Role Admin = new(nameof(Admin), 1);
        public static readonly Role User = new(nameof(User), 2);

        public static implicit operator Role(string name)
            => FromName(name);

        public static implicit operator Role(int value)
            => FromValue(value);

        public static implicit operator string(Role status)
            => status.Name;

        public static implicit operator int(Role status)
            => status.Value;
    }
}