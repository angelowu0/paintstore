using System;
using PaintStore.Models.DTOs;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models.Interfaces.Services;
using PaintStore.Models.Models;
using AutoMapper;

namespace PaintStore.Services.Services;

public class UserService(IUserRepository repo, IMapper mapper) : IUserService
{

    private IMapper _mapper = mapper;
    private readonly IUserRepository _repo = repo;

    public UserResponse CreateUser(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);

        var newUser = _repo.CreateUser(user);

        var userResponse = _mapper.Map<UserResponse>(newUser);

        return userResponse;
    }

    public UserResponse? DeleteUser(int id)
    {
        var deletedUser = _repo.DeleteUser(id);
        var userResponse = _mapper.Map<UserResponse>(deletedUser);
        return userResponse;

    }

    public UserResponse? GetUserById(int id)
    {
        var user = _repo.GetUserById(id);
        var userResponse = _mapper.Map<UserResponse>(user);
        return userResponse;
    }

    public List<UserResponse> GetUsers()
    {
        var users = _repo.GetUsers();
        var usersResponse = _mapper.Map<List<UserResponse>>(users);
        return usersResponse;
    }

    public UserResponse? UpdateUser(int id, UpdateUserRequest request)
    {
        var user = _mapper.Map<User>(request);

        if (_repo.GetUserById(id) == null) return null;

        var updatedUser = _repo.UpdateUser(id, user);

        var userResponse = _mapper.Map<UserResponse>(updatedUser);
        return userResponse;
    }
}
