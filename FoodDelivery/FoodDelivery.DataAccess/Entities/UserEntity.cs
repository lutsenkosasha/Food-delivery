using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.DataAccess.Entities;

[Table("users")]
public class UserEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Adress { get; set; }
    public string Avatar { get; set; }

    public int DeliveryId { get; set; }
    public DeliveryEntity Delivery { get; set; }

    public int AdminID { get; set; }
    public AdminEntity Admin { get; set; }

    public virtual ICollection<OrderEntity> Orders { get; set; }

    // ctrl+k+d+r+g+s - форматирование
}
