using System;
using PaintStore.Repositories;
using PaintStore.Services.Services;
using Xunit;
using Moq;
using PaintStore.Models.Interfaces.Repositories;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PaintStore.API.Mapping;
using PaintStore.Models.Models;

namespace PaintStore.Tests;

public class UserServiceTests
{
    private Mock<IUserRepository> _mockUserRepository;
    private IMapper _mapper;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();
    }

    // Naming pattern for test method
    // What____When___Should
    [Fact]
    public void CreateUserAsync_WhenUserRepositorySucceeds_ReturnNewUser()
    {
        // Arrage
        // prepare new mock data
        var user = new Models.DTOs.CreateUserRequest() { Name = "name", Email = "123@email.com" };
        var userRepo = new User() { Id = 1, Name = "name", Email = "123@email.com" };
        var userRes = new Models.DTOs.UserResponse() { Id = 1, Name = "name", Email = "123@email.com" };


        var userService = new UserService(_mockUserRepository.Object, _mapper);

        _mockUserRepository.Setup(m => m.CreateUser(It.IsAny<User>())).Returns(userRepo);

        // Act
        var result = userService.CreateUser(user);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.Email.Should().Be("123@email.com");
    }

    [Fact]
    public async Task CreateUserAsync_WhenUserRepoFailedToSave_ThrowsException()
    {
        // Arrange
        var user = new Models.DTOs.CreateUserRequest() { Name = "name", Email = "123@email.com" };
        var userRepo = new User() { Id = 1, Name = "name", Email = "123@email.com" };
        var userService = new UserService(_mockUserRepository.Object, _mapper);
        _mockUserRepository.Setup(m => m.CreateUser(It.IsAny<User>()))
        .Throws(new DbUpdateException("Add user failed"));





        // Act & assert
        Assert.Throws<DbUpdateException>(() => userService.CreateUser(user));
    }
}
