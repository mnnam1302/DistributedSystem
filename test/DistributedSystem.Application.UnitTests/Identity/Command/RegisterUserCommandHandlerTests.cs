using DistributedSystem.Application.Abstractions;
using DistributedSystem.Application.UseCases.V1.Commands.Identity;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Domain.Abstractions.Repositories;
using DistributedSystem.Domain.Entities.Identity;
using DistributedSystem.Domain.Errors;
using FluentAssertions;
using Moq;
using System.Linq.Expressions;
using static DistributedSystem.Contract.Services.V1.Identity.Command;

namespace DistributedSystem.Application.UnitTests.Identity.Command;

public class RegisterUserCommandHandlerTests
{
    private readonly Mock<IRepositoryBase<AppUser, Guid>> _userRepositoryMock;
    private readonly Mock<IPasswordHasherService> _passwordHasherServiceMock;

    public RegisterUserCommandHandlerTests()
    {
        _userRepositoryMock = new();
        _passwordHasherServiceMock = new();
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenEmailAlreadyExists()
    {
        // Arrange
        var command = new RegisterUserCommand("first", "last", new DateTime(2002, 02, 13), "0969958958", "nam608072@@gmail.com", "nam123", "nam123");

        _userRepositoryMock.Setup(
           x => x.FindSingleAsync(
               It.IsAny<Expression<Func<AppUser, bool>>?>(),
               It.IsAny<CancellationToken>(),
               It.IsAny<Expression<Func<AppUser, object>>[]>()))
           .ReturnsAsync(AppUser.Create(
                           Guid.NewGuid(),
                           "Nhat",
                           "Nam",
                           new DateTime(2000, 01, 01),
                           "0969958958",
                           "nam608072@gmail.com",
                           "7xjesfznbebOywSlJlKQCSvVJBXwADXbLzDma+PFfy+Q0WtowUkVKyM+lGVoE6ur6a/++LHjy7grvRlelGO9Zw==",
                           "FBH9uVRWPRrRG6LC34ae2f2G1DuZna41Ws6mLaPf32oQSmUSzVcrJK2N+FbK+cIU2JD4aFZkZTYxtK0E0mykMA=="));

        var handler = new RegisterUserCommandHandler(
            _userRepositoryMock.Object,
            _passwordHasherServiceMock.Object);

        // Act
        Result result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(UserErrors.EmailAlreadyInUse(command.Email));
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenEmailNotExists()
    {
        // Arrange
        var command = new RegisterUserCommand("first", "last", new DateTime(2002, 02, 13), "0969958958", "nam608072@@gmail.com", "nam123", "nam123");

        _userRepositoryMock.Setup(
            x => x.FindSingleAsync(
                It.IsAny<Expression<Func<AppUser, bool>>?>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<AppUser, object>>[]>()
            ))
            .ReturnsAsync((AppUser)null);


        var handler = new RegisterUserCommandHandler(
            _userRepositoryMock.Object,
            _passwordHasherServiceMock.Object);

        // Act
        Result result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_CallGenerateSalt_WhenEmailNotExists()
    {
        // Arrange
        var command = new RegisterUserCommand("first", "last", new DateTime(2002, 02, 13), "0969958958", "nam608072@@gmail.com", "nam123", "nam123");

        _userRepositoryMock.Setup(
                       x => x.FindSingleAsync(
                       It.IsAny<Expression<Func<AppUser, bool>>?>(),
                       It.IsAny<CancellationToken>(),
                       It.IsAny<Expression<Func<AppUser, object>>[]>()))
            .ReturnsAsync((AppUser)null);

        _passwordHasherServiceMock.Setup(
                       x => x.GenerateSalt())
            .Returns("FBH9uVRWPRrRG6LC34ae2f2G1DuZna41Ws6mLaPf32oQSmUSzVcrJK2N+FbK+cIU2JD4aFZkZTYxtK0E0mykMA==");

        var handler = new RegisterUserCommandHandler(
                       _userRepositoryMock.Object,
                       _passwordHasherServiceMock.Object);

        // Act
        Result result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _passwordHasherServiceMock.Verify(
            x => x.GenerateSalt(),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_CallHashPassword_WhenEmailNotExists()
    {
        // Arrange
        var command = new RegisterUserCommand("first", "last", new DateTime(2002, 02, 13), "0969958958", "nam608072@@gmail.com", "nam123", "nam123");

        _userRepositoryMock.Setup(
            x => x.FindSingleAsync(
                It.IsAny<Expression<Func<AppUser, bool>>?>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<AppUser, object>>[]>()))
            .ReturnsAsync((AppUser)null);

        _passwordHasherServiceMock.Setup(
                x => x.GenerateSalt())
            .Returns("FBH9uVRWPRrRG6LC34ae2f2G1DuZna41Ws6mLaPf32oQSmUSzVcrJK2N+FbK+cIU2JD4aFZkZTYxtK0E0mykMA==");

        _passwordHasherServiceMock.Setup(
                x => x.HashPassword(It.IsAny<string>(), It.IsAny<string>()))
            .Returns("FBH9uVRWPRrRG6LC34ae2f2G1DuZna41Ws6mLaPf32oQSmUSzVcrJK2N+FbK+cIU2JD4aFZkZTYxtK0E0mykMA==");

        var handler = new RegisterUserCommandHandler(
            _userRepositoryMock.Object,
            _passwordHasherServiceMock.Object);

        // Act
        Result result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _passwordHasherServiceMock.Verify(
            x => x.HashPassword(It.IsAny<string>(), It.IsAny<string>()),
                                Times.Once);
    }

    [Fact]
    public async Task Handle_Should_CallAddOnRepository_WhenEmailNotxsist()
    {
        // Arrange
        var command = new RegisterUserCommand("first", "last", new DateTime(2002, 02, 13), "0969958958", "nam608072@@gmail.com", "nam123", "nam123");

        _userRepositoryMock.Setup(
            x => x.FindSingleAsync(
                It.IsAny<Expression<Func<AppUser, bool>>?>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<AppUser, object>>[]>()
            ))
            .ReturnsAsync((AppUser)null);

        _passwordHasherServiceMock.Setup(
                                  x => x.GenerateSalt())
            .Returns("FBH9uVRWPRrRG6LC34ae2f2G1DuZna41Ws6mLaPf32oQSmUSzVcrJK2N+FbK+cIU2JD4aFZkZTYxtK0E0mykMA==");

        _passwordHasherServiceMock.Setup(
            x => x.HashPassword(It.IsAny<string>(), It.IsAny<string>()))
            .Returns("FBH9uVRWPRrRG6LC34ae2f2G1DuZna41Ws6mLaPf32oQSmUSzVcrJK2N+FbK+cIU2JD4aFZkZTYxtK0E0mykMA==");


        var handler = new RegisterUserCommandHandler(
            _userRepositoryMock.Object,
            _passwordHasherServiceMock.Object);

        // Act
        Result result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _userRepositoryMock.Verify(
            x => x.Add(It.IsAny<AppUser>()), 
            Times.Once);
    }
}