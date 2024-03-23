using FluentAssertions;
using NetArchTest.Rules;

namespace DistributedSystem.ArchitectureTests;

public class ArchitectureTests
{
    private const string DomainNamespace = "DistributedSystem.Domain";
    private const string ApplicationNamespace = "DistributedSystem.Application";
    private const string InfrastructureNamespace = "DistributedSystem.Infrastructure";
    private const string PersistenceNamespace = "DistributedSystem.Persistence";
    private const string PresentationNamespace = "DistributedSystem.Presentation";
    private const string ApiNamespace = "DistributedSystem.API";

    /// <summary>
    /// Domain should not have any dependencies
    /// </summary>
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var domain = DistributedSystem.Domain.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var result = Types
            .InAssembly(domain)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// Application should not depend on Infrastructure, Presentation, API.
    /// </summary>
    [Fact]
    public void Application_Should_Not_HaveDependencyOtherProjects()
    {
        // Arrange
        var application = DistributedSystem.Application.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var result = Types
            .InAssembly(application)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// Infrastructure should depend on Application
    /// TranDong: Let's check again, Although referenced, but it's not used.
    /// </summary>
    [Fact]
    public void Infrastructure_Should_HaveDependencyOnApplication()
    {
        // Arrange
        var infrastructure = DistributedSystem.Infrastructure.AssemblyReference.Assembly;

        // Act
        var result = Types
            .InAssembly(infrastructure)
            .Should()
            .HaveDependencyOn(ApplicationNamespace)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// Persistence should depend on Domain.
    /// </summary>
    [Fact]
    public void Persistence_Should_HaveDependecyOnDomain()
    {
        // Arrange
        var persistence = DistributedSystem.Persistence.AssemblyReference.Assembly;

        // Act
        var result = Types
            .InAssembly(persistence)
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}
