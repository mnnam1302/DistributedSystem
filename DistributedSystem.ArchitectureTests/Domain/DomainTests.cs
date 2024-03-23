using DistributedSystem.Domain.Abstractions.Entities;
using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace DistributedSystem.ArchitectureTests.Domain;

public class DomainTests
{
    // Let's check later
    [Fact]
    public void Entities_Should_HavePrivateParameterlessConstructor()
    {
        var entitiyTypes = Types.InAssembly(DistributedSystem.Domain.AssemblyReference.Assembly)
            .That()
            .Inherit(typeof(Entity<Guid>))
            .GetTypes();

        var failingTypes = new List<Type>();

        foreach (var entityType in entitiyTypes)
        {
            var constructors = entityType.GetConstructors(BindingFlags.Instance | 
                                                          BindingFlags.NonPublic);

            if (!constructors.Any(c => c.IsPrivate && c.GetParameters().Length == 0))
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }
}
