using System.ComponentModel.DataAnnotations;

namespace Sklep.Models
{
    public class ShoppingList
    {
        [Key]
        public Guid Id { get; set; }    
        public string? Description { get; set; }
        public bool Check {  get; set; }    
    }
}
