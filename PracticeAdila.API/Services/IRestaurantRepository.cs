using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeAdila.Data;

namespace OdeToFood.Api.Services
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllAsync();
        Task<Restaurant> AddAsync(Restaurant restaurant);
        Task<Restaurant> GetByIdAsync(int id);
        Task UpdateAsync(Restaurant restaurant);
        Task DeleteAsync(int id);
    }
}
