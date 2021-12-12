using System;
using System.ComponentModel.DataAnnotations;

namespace Server.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Fullname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Password { get; set; }
    }
}