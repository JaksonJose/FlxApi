﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Flx.Domain.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
