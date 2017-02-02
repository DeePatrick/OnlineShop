using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineShop.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a Manga Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "please enter a positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        [Required]
        public byte[] BrandImage { get; set; }

        public void Modify(string name, string description, decimal price, string category, string genre)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Genre = genre;
        }
    }
}

 