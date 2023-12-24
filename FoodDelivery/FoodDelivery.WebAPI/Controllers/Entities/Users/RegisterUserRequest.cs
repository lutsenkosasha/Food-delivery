namespace FoodDelivery.WebAPI.Controllers.Entities.Users;

public class RegisterUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Adress { get; set; }
    public string Avatar { get; set; }

    public int DeliveryId { get; set; }
}
