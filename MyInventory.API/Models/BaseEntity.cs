using System.ComponentModel.DataAnnotations;

namespace MyInventory.API.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
