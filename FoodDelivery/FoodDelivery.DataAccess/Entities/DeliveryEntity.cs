using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.DataAccess.Entities;

[Table("deliveries")]
public class DeliveryEntity : BaseEntity
{
    public string Title { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }

    public virtual ICollection<UserEntity> Users { get; set; }
}
