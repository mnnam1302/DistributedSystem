using System.Reflection;

namespace DistributedSystem.Presentation
{
    public static class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
    }
}