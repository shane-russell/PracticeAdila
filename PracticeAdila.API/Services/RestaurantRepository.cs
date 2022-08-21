using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticeAdila.Data;

namespace OdeToFood.Api.Services
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly PracticeAdilaDbContext _context;

        public RestaurantRepository(PracticeAdilaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Restaurant> AddAsync(Restaurant restaurant)
        {
            _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            return restaurant;
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            var original = await _context.Restaurants.FindAsync(restaurant.Id);

            original.City = restaurant.City;
            original.Country = restaurant.Country;
            original.Name = restaurant.Name;

            //var entry = _context.Entry(original);

            //entry.CurrentValues.SetValues(restaurant);

            _context.Update(original);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var restaurant = await GetByIdAsync(id);

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}
