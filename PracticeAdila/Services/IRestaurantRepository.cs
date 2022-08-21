using PracticeAdila.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAdila.Api
{
    public interface IRestaurantRepository
    {
        public Task<IList<Restaurant>> GetAllRestaurantsAsync();
        public Task<Restaurant> GetByIdAsync(int id);

        public Task<Restaurant> AddAsync(Restaurant restaurant);

        public Task UpdateAsync(Restaurant restaurant);

        public Task DeleteAsync(int id);
    }
}
