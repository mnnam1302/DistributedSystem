using DistributedSystem.Contract.Abstractions.Message;
using FluentAssertions;
using NetArchTest.Rules;

namespace DistributedSystem.ArchitectureTests.Contract;

public class ContractTest
{
    [Fact]
    public void DomainEvents_Should_BeSealed()
    {
        var result = Types.InAssembly(DistributedSystem.Contract.AssemblyReference.Assembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .BeSealed()
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEvents_Should_HaveDomainEventPostfix()
    {
        var result = Types.InAssembly(DistributedSystem.Contract.AssemblyReference.Assembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .HaveNameEndingWith("DomainEvent")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
