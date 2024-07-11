using System.ComponentModel.DataAnnotations;

namespace Icecream.Api.Data.Entities
{
    public class IceCream
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Range(0.1, double.MaxValue) ]
        private double Price { get; set; }

        [Required, MaxLength(180)]
        public string Image { get;set; }
        public virtual ICollection<IceCreamOptions> Options { get; set; }
    }
}
