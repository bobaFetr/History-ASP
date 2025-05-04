using Microsoft.AspNetCore.Mvc;
using MyMvcApp.DAL;
using MyMvcApp.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MyMvcApp.Controllers
{
    public class LandmarkController : Controller
    {
        private readonly LandmarkRepository _repo;

        public LandmarkController(IConfiguration config)
        {
            _repo = new LandmarkRepository(config.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            List<Landmark> landmarks = _repo.GetAllLandmarks();
            return View(landmarks);
        }
    }
}
