using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Artisanal.Services.CustomIdentity.Models.DAO;

public class LoginDAO
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(30)]
    public string UserName { get; set; }
    [Required]
    public string HashedPassword { get; set; }
    [Required]
    public RoleDAO Role;

}
