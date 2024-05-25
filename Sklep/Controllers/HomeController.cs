using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sklep.Models;
using Sklep.Service.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sklep.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAddShopList _shopList;
        public HomeController(IAddShopList shopList)
        {
            _shopList = shopList;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Lista() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Add(string list)
        {
            ShoppingList shoppingList = new ShoppingList();
            shoppingList.Description = list;
            _shopList.AddToShopList(shoppingList);
            return View();
        }
        public IActionResult Remove(ShoppingList list)
        {
            _shopList.ExistingShopList(list);
            _shopList.RemoveFromShopList(list);
            return View();
        }
        public IActionResult ShowAll()
        {
            var showAll = _shopList.ShowAllShopList();
            return View(showAll);
        }
        
    }
}
