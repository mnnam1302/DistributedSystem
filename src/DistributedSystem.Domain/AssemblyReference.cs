using System.Reflection;

namespace DistributedSystem.Domain
{
    public static class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
    }
}