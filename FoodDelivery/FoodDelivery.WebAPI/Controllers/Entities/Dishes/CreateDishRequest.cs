using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.WebAPI.Controllers.Entities.Dishes;

public class CreateDishRequest : IValidatableObject
{
    [Required]
    public string DishName { get; set; }
    [Required]
    public string Description { get; set; }
    [Range(50, 2000)]
    public int NumberOfGrams { get; set; }
    [Required]
    public string NutritionalValue { get; set; }
    [Range(100, 10000)]
    public int Price { get; set; }
    [Required]
    public int DishInOrderID { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        return errors;
    }
}
