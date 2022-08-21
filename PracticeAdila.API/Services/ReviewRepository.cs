using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticeAdila.Data;

namespace OdeToFood.Api.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly PracticeAdilaDbContext _context;

        public ReviewRepository(PracticeAdilaDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(review => review.Id == id);
        }

        public async Task<Review> AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task UpdateAsync(Review review)
        {
            var original = _context.Reviews.Find(review.Id);

            original.Rating = review.Rating;
            original.Body = review.Body;
            original.RestaurantId = review.RestaurantId;
            original.Restaurant = review.Restaurant;
            original.ReviewerName = review.ReviewerName;

            //var entry = _context.Entry(original);

            //entry.CurrentValues.SetValues(review);

            _context.Update(original);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var review = await GetByIdAsync(id);

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
