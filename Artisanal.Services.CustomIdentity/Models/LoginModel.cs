using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Artisanal.Services.CustomIdentity.Models;

public class LoginModel{
    [Required]
    [StringLength(30)]
    public string UserName { get; set; }
    [Required]
    [StringLength(30)]
    [PasswordPropertyText]
    public string Password { get; set; }

    
}