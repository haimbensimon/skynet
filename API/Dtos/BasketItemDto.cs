using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0.1,double.MaxValue,ErrorMessage = "price must be grater than Zero")]
        public decimal Price { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Quantity cannot be zero !")]
        public int Quantity { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]

        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
    }
}