using System;
using PaintStore.Models.Models;

namespace PaintStore.Models.Interfaces.Repositories;

public interface IUserRepository
{
    public User CreateUser(User user);

    public List<User> GetUsers();

    public User? GetUserById(int id);

    public User? UpdateUser(int id, User user);

    public User? DeleteUser(int id);

}
