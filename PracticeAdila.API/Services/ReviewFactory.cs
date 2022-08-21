using PracticeAdila.Data;
using PracticeAdila.Data.DomainClasses;

namespace PracticeAdila.API.Services
{
    public class ReviewFactory : IReviewFactory
    {
        public Review Create(Restaurant restaurant, ReviewModel reviewModel)
        {
            Review review = new Review();
            review.Restaurant = restaurant;
            review.RestaurantId = restaurant.Id;
            review.ReviewerName= reviewModel.ReviewerName;
            review.Rating = reviewModel.Rating;
            review.Body = reviewModel.Body;

            return review;
        }
    }
}
