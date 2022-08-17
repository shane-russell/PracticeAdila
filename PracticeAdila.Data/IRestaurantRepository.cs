using PracticeAdila.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAdila.Data
{
    public interface IRestaurantRepository
    {
        public IList<Restaurant> GetAllRestaurants();
    }
}
