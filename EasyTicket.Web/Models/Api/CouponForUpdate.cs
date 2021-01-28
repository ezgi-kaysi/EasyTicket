using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTicket.Web.Models.Api
{
    public class CouponForUpdate
    {
        [Required]
        public Guid CouponId { get; set; }
    }
}
