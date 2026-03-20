using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.DataAccess;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models.Models;

namespace PaintStore.Repositories;

public class UserRepository(PaintStoreDbContext paintStoreDb) : IUserRepository
{
    private readonly PaintStoreDbContext _db = paintStoreDb;

    public User CreateUser(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
        return user;
    }

    public User? DeleteUser(int id)
    {
        User? user = GetUserById(id);
        if (user == null) return null;
        _db.Users.Remove(user);
        return user;
    }

    public User? GetUserById(int id)
    {
        User? user = _db.Users.FirstOrDefault(user => user.Id == id);
        return user;
    }

    public List<User> GetUsers()
    {
        List<User> users = [.. _db.Users];
        return users;
    }

    public User? UpdateUser(int id, User updatedUser)
    {
        User? user = GetUserById(id);
        if (user == null) return null;
        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        _db.SaveChanges();
        return user;
    }
}
