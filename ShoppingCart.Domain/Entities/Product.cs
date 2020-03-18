using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShoppingCart.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field is required.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price field is required.")]
        [Range(0.00, Double.MaxValue, ErrorMessage = "Price should be a positive value.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category field is required.")]
        public string Category { get; set; }
    }
}
