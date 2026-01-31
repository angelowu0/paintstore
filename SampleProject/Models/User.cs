using System;
using SampleProject.Enums;

namespace SampleProject.Models;

public class User(string name, int age)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;

    public void DisplayUserInfo()
    {
        string description = $"{Name} {Age}";
        Console.WriteLine(description);
    }
}
