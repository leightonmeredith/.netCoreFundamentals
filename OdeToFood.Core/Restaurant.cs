using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant //:IValidatableObject allows custom code writing for custom check
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public CuisineType Type { get; set; }
    }
}
