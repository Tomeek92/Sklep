using Sklep.Models;

namespace Sklep.Service.Interfaces
{
    public interface IAddShopList
    {
        public void AddToShopList(ShoppingList list);
        public void RemoveFromShopList(ShoppingList list);
        public void ExistingShopList(ShoppingList list);
        public List<string> ShowAllShopList();
    }
}
