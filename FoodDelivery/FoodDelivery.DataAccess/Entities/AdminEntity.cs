using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.DataAccess.Entities;

[Table("admins")]
public class AdminEntity : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
