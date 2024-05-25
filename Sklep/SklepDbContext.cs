using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sklep.Models;

namespace Sklep
{
    public class SklepDbContext : DbContext
    {
        public SklepDbContext(DbContextOptions<SklepDbContext> options) : base(options) { }

        public DbSet<ShoppingList> ShoppingLists { get; set; }
           
        
    }
}
