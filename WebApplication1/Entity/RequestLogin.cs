﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entity;

public class RequestLogin
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}