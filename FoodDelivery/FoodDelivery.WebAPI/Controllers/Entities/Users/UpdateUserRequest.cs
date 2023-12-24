using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.WebAPI.Controllers.Entities.Users;

public class UpdateUserRequest : IValidatableObject
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [MinLength(12)]
    [MaxLength(18)]
    public string Password { get; set; }
    [Required]
    public string Adress { get; set; }
    public string Avatar { get; set; }
    [Required]
    public int DeliveryId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return new List<ValidationResult>();
    }
}
