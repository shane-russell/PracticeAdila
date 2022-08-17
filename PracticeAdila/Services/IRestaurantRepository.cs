using PracticeAdila.Data;
using PracticeAdila.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace PracticeAdila.Api
{
    public interface IRestaurantRepository
    {
        public IList<Restaurant> GetAllRestaurants();
        public Restaurant GetById(int id);
    }
}
