using Amigos.Application.Interfaces;
using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Web;

namespace Web.Controllers
{
    public class FriendsController : Controller
    {
        IFriendService _context;
        List<FriendViewModel> selectedList = new List<FriendViewModel>();

        public FriendsController(IFriendService context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Console.WriteLine(selectedList.Count);
            if (selectedList.IsNullOrEmpty())
            {
               List<FriendViewModel> friendsList = await _context.GetAllFriendAsync();
               return View(friendsList.OrderBy(f => f.FirstName).ToList());
            }
            

            return View(selectedList.OrderBy(f => f.FirstName).ToList());
        }

        [HttpPost]
        public ActionResult Index(List<FriendViewModel> model)
        {
           
            foreach (var friend in model)
            {
                if(friend.IsChecked == true)
                {
                    selectedList.Add(friend);
                }
            }

            return View(selectedList.OrderBy(f => f.FirstName).ToList());
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
