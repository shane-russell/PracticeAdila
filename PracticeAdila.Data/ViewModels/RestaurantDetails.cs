using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAdila.Data.ViewModels
{
    public class RestaurantDetails
    {
        public Restaurant Restaurant { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
