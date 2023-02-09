using Amigos.Application.Interfaces;
using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FriendsController : Controller
    {
        IFriendService _context;



        public async Task<IActionResult> Index()
        {
            var friendsList = await _context.GetAllFriendAsync();

            return View(friendsList.OrderBy(f => f.FirstName).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> FriendForm(FriendViewModel model)
        {
            var friend = new Friend(model.FirstName, model.LastName, model.Email, model.BirthDate);

            await _context.AddFriendAsync(friend);

            return RedirectToAction(nameof(Index));
        }
    }
}
