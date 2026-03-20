using System;
using System.ComponentModel.DataAnnotations;

namespace PaintStore.Models.DTOs;

public class CreateUserRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
