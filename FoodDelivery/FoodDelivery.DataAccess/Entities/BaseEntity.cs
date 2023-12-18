using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.DataAccess.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; } // ключ к базе данных

    public Guid ExternalId { get; set; } // внешний ключ - unique index - optional
    public DateTime ModificationTime { get; set; } // optional
    public DateTime CreationTime { get; set; } // optional
}
