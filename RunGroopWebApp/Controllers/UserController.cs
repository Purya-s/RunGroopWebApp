using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;

namespace RunGroopWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhotoService _photoService;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserRepository userRepository, IPhotoService photoService, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _photoService = photoService;
            _userManager = userManager;
        }

        [HttpGet("users")]
        public async Task <IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();

            List<UserViewModel> result = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userVM = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Mileage,
                    City = user.City,
                    State = user.State,
                    ProfileImageUrl=user.ProfileImageUrl ?? "/img/avatar-male-4.jpg",
                };

                result.Add(userVM);
            }

            return View(result);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("Index", "Users");
            }

            var userDetailVM = new UserDetailviewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Pace = user.Pace,
                Mileage = user.Mileage,
                //City = user.City,
                //State = user.State,
                //ProfileImageUrl = user.ProfileImageUrl 
            };

            return View(userDetailVM);
        }
    }
}
