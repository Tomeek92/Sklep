using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sklep.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
namespace Sklep.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly SklepDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingListController(SklepDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

      
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var shoppingLists = await _context.ShoppingLists
                .Where(sl => sl.OwnerId == user.Id)
                .ToListAsync();

            return View(shoppingLists);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(ShoppingList shoppingListItem)
        { 
          if (!ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            shoppingListItem.OwnerId = user.Id;
            shoppingListItem.Id = Guid.NewGuid(); 

            _context.Add(shoppingListItem);
            await _context.SaveChangesAsync();
        }

        return View(shoppingListItem);
        }
        [HttpPost]
        public IActionResult ToggleCheck(Guid id)
        {
            var item = _context.ShoppingLists.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Check= !item.Check;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
     [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description")] ShoppingList shoppingList)
{
    if (id != shoppingList.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(shoppingList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ShoppingListExists(shoppingList.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }
    return View(shoppingList);
}
        private bool ShoppingListExists(Guid id)
        {
            return _context.ShoppingLists.Any(e => e.Id == id);
        }
    
    [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var shoppingList = await _context.ShoppingLists.FindAsync(id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            if (shoppingList.OwnerId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingListItem = await _context.ShoppingLists
                .FirstOrDefaultAsync(sli => sli.Id == id);

            if (shoppingListItem == null)
            {
                return NotFound();
            }

            return View(shoppingListItem);
        }
        [HttpPost]
        public async Task<IActionResult> Details()
        {
            return View();
        }
        
    }
}

