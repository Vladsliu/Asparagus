using Asparagus2.Data;
using Asparagus2.Models;
using Asparagus2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Asparagus2.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(UserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            int countUser = 0;
            if (_dataContext.Users.Any(x => x.Email == viewModel.Email))
            {
                countUser = _dataContext.Users.Count(x => x.Email == viewModel.Email);
            }
            
            var modelUser = new User
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                DateTime = DateTime.Now,
                CountEat = countUser + 1
            };

            _dataContext.Add(modelUser);
            _dataContext.SaveChanges();

            return RedirectToAction("Privacy");
        }

        public IActionResult Privacy()
        {
          
            var users = _dataContext.Users.ToList();
            users.Reverse();
            return View(users);
        }

        [HttpGet]
        public IActionResult Popup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Popup(CallViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Call call = new Call
            { 
            Phone = model.Phone,
            DateTime = DateTime.Now,
            };
            
            _dataContext.Add(call);
            _dataContext.SaveChanges();
            return RedirectToAction("Privacy");
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}