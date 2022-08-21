using Microsoft.EntityFrameworkCore;
using PracticeAdila.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAdila.Api
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly PracticeAdilaDbContext _context;

        public RestaurantRepository(PracticeAdilaDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(restaurant => restaurant.Id == id);
            // return (Restaurant)_context.Restaurants.Where<Restaurant>(restaurant => restaurant.Id == id);

        }

        public async Task<Restaurant> AddAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            return restaurant;
        }

        public async Task UpdateAsync(Restaurant passedRestaurant)
        {
            var original = await _context.Restaurants.FirstOrDefaultAsync(restaurant => restaurant.Id == passedRestaurant.Id);
            original.City = passedRestaurant.City;
            original.Name = passedRestaurant.Name;
            original.Country = passedRestaurant.Country;
            _context.Update(original);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(restaurant => restaurant.Id == id);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}
