using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Api.Services;
using PracticeAdila.API.Services;
using PracticeAdila.Data;
using PracticeAdila.Data.Domain;
using PracticeAdila.Data.DomainClasses;
using PracticeAdila.Data.ViewModels;

namespace OdeToFood.Api.Controllers.Api
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IReviewFactory _reviewFactory;

        public HomeController(IRestaurantRepository restaurantRepository, IReviewRepository reviewRepository, IReviewFactory reviewFactory)
        {
            _restaurantRepository = restaurantRepository;
            _reviewRepository = reviewRepository;
            _reviewFactory = reviewFactory;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var model = await _restaurantRepository.GetAllAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [Route("[Controller]/[action]/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);

            if (restaurant == null)
            {
                return RedirectToAction(nameof(Index));
            }

            IList<Review> reviews = await _reviewRepository.GetAllAsync();
            IEnumerable<Review> restaurantReviews = reviews.Where(review => review.RestaurantId == restaurant.Id);

            RestaurantDetails details = new RestaurantDetails
            {
                Restaurant = restaurant,
                Reviews = restaurantReviews
            };

            var model = details;


            return View(model);
        }

        [Route("[controller]/[action]/{id}")]
        public async Task<IActionResult> AddReview(int id, ReviewModel reviewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            var newReview = _reviewFactory.Create(restaurant, reviewModel);

            await _reviewRepository.AddAsync(newReview);

            return RedirectToAction(nameof(Details), new { id = restaurant.Id }); ;
        }
    }
}