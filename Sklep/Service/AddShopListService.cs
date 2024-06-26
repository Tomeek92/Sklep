﻿using Microsoft.EntityFrameworkCore;
using Sklep.Models;
using Sklep.Service.Interfaces;

namespace Sklep.Service
{
    public class AddShopListService : IAddShopList
    {
        private readonly SklepDbContext _context;
        public AddShopListService(SklepDbContext context)
        {
            _context = context;
        }
        public void AddToShopList(ShoppingList list)
        {
            _context.Add(list);
            _context.SaveChanges();
        }
        public void RemoveFromShopList(ShoppingList list)
        {
            _context.ShoppingLists.Remove(list);
            _context.SaveChanges();
        }
        public void ExistingShopList(ShoppingList list)
        {
            _context.ShoppingLists.Find(list.Id);
        }
        public List<string> ShowAllShopList()
        {
            var users = _context.ShoppingLists.ToList();

            List<string> shopList = new List<string>();

            foreach (var user in users)
            {
                shopList.Add(user.Description);
            }
            return shopList;
        }
    }
}
