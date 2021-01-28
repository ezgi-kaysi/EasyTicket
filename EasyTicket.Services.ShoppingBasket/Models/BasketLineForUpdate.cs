using System.ComponentModel.DataAnnotations;

namespace EasyTicket.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
