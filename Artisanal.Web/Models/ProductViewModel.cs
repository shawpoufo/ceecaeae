namespace Artisanal.Web.Models;
using System.ComponentModel.DataAnnotations;

public class ProductViewModel
{
    [Required]
    public string ProductName { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public string CategoryName { get; set; }
    [Required]
    public string ImageURL { get; set; }
}
