using System.ComponentModel.DataAnnotations;

namespace Artisanal.Services.CustomIdentity.Models.DAO;

public class RoleDAO
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Label { get; set; }
}
