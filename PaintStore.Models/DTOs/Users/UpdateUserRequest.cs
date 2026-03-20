using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PaintStore.Models.DTOs;

public class UpdateUserRequest
{
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}
