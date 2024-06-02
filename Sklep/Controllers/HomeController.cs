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
        private readonly SklepDbContext _context;
        public HomeController(IAddShopList shopList, SklepDbContext context)
        {
            _shopList = shopList;
           _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Lista() {
            var showAll = _shopList.ShowAllShopList();
            if (showAll == null)
            {
                return View(showAll);
            }
            else
            {
                return View(showAll);
            }
        }
        [HttpPost]
        public  IActionResult Add(ShoppingList list)
        {
            _shopList.AddToShopList(list);
           return RedirectToAction("Lista","Home");
        }
       
        public IActionResult Remove(string shoppingList)
        {
            try
            {
                var elementDoUsuniecia = _context.ShoppingLists.FirstOrDefault(u => u.Description == shoppingList);
                if (elementDoUsuniecia == null)
                {
                    return NotFound();
                }
                _shopList.RemoveFromShopList(elementDoUsuniecia);
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd usuniecia produktu" + ex.Message);
            }
            return RedirectToAction("Lista", "Home");
        }
        public IActionResult ShowAll()
        {
            var showAll = _shopList.ShowAllShopList();
            if(showAll == null)
            {
                return View(showAll);
            }
            else
            {
                return View(showAll);
            }
        }
        
    }
}
