using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ScheduleAPI.Controllers;
using ScheduleAPI.Dtos;
using ScheduleAPI.Interface;
using ScheduleAPI.Models;
using ScheduleAPI.Service;
using Xunit;

public class UserControllerTests
{
    //Arrange
    private readonly Mock<UserService> userServiceMock = new Mock<UserService>();
    private readonly Mock<IMapper> mapperMock = new Mock<IMapper>();
    
    [Fact]
    public void AddUserTest()
    {
        userServiceMock.Setup(m => m.AddUser(It.IsAny<CreateUserDto>()));
        var controller = new UserController(userServiceMock.Object, mapperMock.Object);

        var createUserDto = new CreateUserDto { UserName = "Joao", Email = "joao@gmail.com", PhoneNumber = "81997810293" };
        var user = new User { UserName = "Joao", Email = "joao@gmail.com", PhoneNumber = "81997810293" };

        mapperMock.Setup(m => m.Map<User>(createUserDto)).Returns(user);

        // Act
        var result = controller.AddUser(createUserDto) as CreatedAtActionResult;

        // Assert
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void GetUsersTest()
    {
        var users = new List<ReadUserDto>(); 
        userServiceMock.Setup(s => s.GetUsers(0, 100)).Returns(users);
        var controller = new UserController(userServiceMock.Object, mapperMock.Object);

        // Act
        var result = controller.GetUsers(0, 100);

        // Assert
        Assert.Equal(users, result);
    }

    [Fact]
    public void GetUserByIdTest()
    {
        var user = new User { Id = 1 };
        userServiceMock.Setup(s => s.GetUserById(1)).Returns(user);

        var controller = new UserController(userServiceMock.Object, mapperMock.Object);

        // Act
        var result = controller.GetUserById(1);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, actionResult.StatusCode);
    }

    [Fact]
    public void UpdateUserTest()
    {
        var userDto = new UpdateUserDto();
        var user = new User();
        userServiceMock.Setup(s => s.UpdateUser(1, userDto)).Returns(user);

        var controller = new UserController(userServiceMock.Object, mapperMock.Object);

        // Act
        var result = controller.UpdateUser(1, userDto);

        // Assert
        var actionResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, actionResult.StatusCode);
    }

    [Fact]
    public void UpdateUserInvalidIdTest()
    {
        var userDto = new UpdateUserDto();
        userServiceMock.Setup(s => s.UpdateUser(1, userDto)).Returns((User)null);

        var controller = new UserController(userServiceMock.Object, mapperMock.Object);

        // Act
        var result = controller.UpdateUser(1, userDto);

        // Assert
        var actionResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(404, actionResult.StatusCode);
    }

    [Fact]
    public void DeleteUserTest()
    {
        var user = new User { Id = 1 };
        userServiceMock.Setup(s => s.GetUserById(1)).Returns(user);

        var controller = new UserController(userServiceMock.Object, mapperMock.Object);

        // Act
        var result = controller.DeleteUser(1);

        // Assert
        var actionResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, actionResult.StatusCode);
    }

    [Fact]
    public void DeleteUserInvalidIdTest()
    {
        userServiceMock.Setup(s => s.GetUserById(1)).Returns((User)null);

        var controller = new UserController(userServiceMock.Object, mapperMock.Object);

        // Act
        var result = controller.DeleteUser(1);

        // Assert
        var actionResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(404, actionResult.StatusCode);
    }
}
