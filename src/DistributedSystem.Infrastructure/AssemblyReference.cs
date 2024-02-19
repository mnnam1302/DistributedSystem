using System.Reflection;

namespace DistributedSystem.Infrastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
    }
}