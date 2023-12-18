using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.DataAccess.Entities
{
    [Table("dishesinorders")]
    public class DishInOrderEntity : BaseEntity
    {
        public int Count { get; set; }

        public virtual ICollection<DishEntity> Dishes { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
