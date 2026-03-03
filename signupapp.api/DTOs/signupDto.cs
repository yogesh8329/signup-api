using System.ComponentModel.DataAnnotations;

namespace SignupApp.API.DTOs;

public class SignupRequestDto
{
    [Required]
    public string Email { get; set; }


    [Required]
    public string Password { get; set; }
}
