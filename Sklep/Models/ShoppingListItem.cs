
using System.ComponentModel.DataAnnotations;

namespace Sklep.Models
{
    public class ShoppingListItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string OwnerId { get; set; }
        public bool IsChecked { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public ShoppingListItem()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
