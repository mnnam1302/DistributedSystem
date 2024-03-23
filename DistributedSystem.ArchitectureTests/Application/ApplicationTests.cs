using DistributedSystem.Contract.Abstractions.Message;
using FluentAssertions;
using NetArchTest.Rules;

namespace DistributedSystem.ArchitectureTests.Application;

public class ApplicationTests
{
    // Command handlers must end with CommandHandler
    [Fact]
    public void CommandHandlers_Should_HaveCommandHandlerPostfix()
    {
        var result = Types.InAssembly(DistributedSystem.Application.AssemblyReference.Assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }


}
