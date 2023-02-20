using Amigos.Application.Interfaces;
using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web;

namespace Web.Controllers
{
    public class FriendsController : Controller
    {
        IFriendService _context;


        public FriendsController(IFriendService context)
        {
            _context = context;
        }

        #region private_methods

        private void SetSession(List<Guid> Selected)
        {
            HttpContext.Session.SetString("Selected", JsonConvert.SerializeObject(Selected));
        }
        private List<Guid> GetSession()
        {
            var selectedList = HttpContext.Session.GetString("Selected");
            if (!string.IsNullOrEmpty(selectedList))
            {
                return JsonConvert.DeserializeObject<List<Guid>>(HttpContext.Session.GetString("Selected"));
            }
            return new List<Guid>();
        }
        #endregion


        public async Task<IActionResult> Index()
        {

            var session = GetSession();


            List<FriendViewModel> friendsList = await _context.GetAllFriendAsync();

            foreach(var friend in friendsList)
            {
                friend.IsChecked = session.Contains(friend.Id);
            }

            return View(friendsList.OrderBy(f => f.FirstName).ToList());

        }

        public async Task<IActionResult> FriendsEmail()
        {

            var session = GetSession();


            List<FriendViewModel> friendsList = await _context.GetAllFriendAsync();

            foreach (var friend in friendsList)
            {
                friend.IsChecked = session.Contains(friend.Id);
            }



            return View(friendsList.OrderBy(f => f.FirstName).ToList());

        }

        [HttpPost]
        [Route("/friends/selected")]
        public async Task<ActionResult> Selected(List<Guid> selected)
        {
            SetSession(selected);
            
            var friendList = await _context.GetSelectedFriends(selected);
            
            return View(friendList);
        }

        public async Task<IActionResult> FriendForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FriendForm(FriendViewModel model)
        {

            await _context.AddFriendAsync(model);


            Console.WriteLine("Adicionado");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Guid Id)
        {
            _context.DeleteFriendAsync(Id);

            return RedirectToAction(nameof(Index));
        }

    }
}
