namespace Artisanal.Web.Models;

using System.ComponentModel.DataAnnotations;

public class LoginViewModel{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string PassWord { get; set; }
}