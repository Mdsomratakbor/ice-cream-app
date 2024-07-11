using System.ComponentModel.DataAnnotations;

namespace Icecream.Api.Data.Entities
{
    public class IceCreamOptions
    {
        public int IceCreamId { get; set; }

        [Required, MaxLength(50)]
        public string Flavor { get; set; }
        [Required, MaxLength(50)]
        public string Topping { get; set; }
        public virtual IceCream IceCream { get; set; }
    }
}
