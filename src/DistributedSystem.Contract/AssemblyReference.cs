using System.Reflection;

namespace DistributedSystem.Contract
{
    public static class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
    }
}