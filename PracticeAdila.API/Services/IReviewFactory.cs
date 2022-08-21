using PracticeAdila.Data;
using PracticeAdila.Data.DomainClasses;

namespace PracticeAdila.API.Services
{
    public interface IReviewFactory
    {
        Review Create(Restaurant restaurant, ReviewModel reviewModel);
    }
}
