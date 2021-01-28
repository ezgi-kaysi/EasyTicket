using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTicket.Services.ShoppingBasket.Models
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
