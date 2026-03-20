using System;
using PaintStore.Models.DTOs;
using PaintStore.Models.Models;
namespace PaintStore.Models.Interfaces.Services;

public interface IUserService
{
    public UserResponse CreateUser(CreateUserRequest request);

    public List<UserResponse> GetUsers();

    public UserResponse? GetUserById(int id);

    public UserResponse? UpdateUser(int id, UpdateUserRequest request);

    public UserResponse? DeleteUser(int id);
}
