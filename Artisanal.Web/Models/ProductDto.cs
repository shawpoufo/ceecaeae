using System.ComponentModel.DataAnnotations;

namespace Artisanal.Web.Models
{
    public class ProductDto
    {
       
        public int ProductId { get; set; }
        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }
   
        public double Price { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }


    }
}
