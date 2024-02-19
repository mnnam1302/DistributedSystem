using System.Reflection;

namespace DistributedSystem.Persistence
{
    public static class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
    }
}