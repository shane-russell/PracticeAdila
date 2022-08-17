using Microsoft.AspNetCore.Mvc;
using PracticeAdila.Data;
using PracticeAdila.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PracticeAdila.Api.Controllers
{
    public class HomeController : Controller

        
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public HomeController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [Route("")]
        public IActionResult Index()
        {
            IList<Restaurant> restaurantsModel = _restaurantRepository.GetAllRestaurants().ToList();
            if (restaurantsModel == null)
            {
                return NotFound();
            }
            /*
            var words = new List<string>();
            
            words.Add("one");
            words.Add("two");


            ViewBag.TwoWords = words;

            ViewData["Dinosaur"] = "T-Rex";
            */
            return View(restaurantsModel);
        }

        [Route("[Controller]/[action]/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var restaurant = _restaurantRepository.GetById(id);

            if (restaurant == null)
            {
                return RedirectToAction(nameof(Index));
            }
        }
}