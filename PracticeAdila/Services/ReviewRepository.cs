using Microsoft.EntityFrameworkCore;
using PracticeAdila.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAdila.Api
{
    internal class ReviewRepository
    {
        private readonly PracticeAdilaDbContext _context;

        public ReviewRepository(PracticeAdilaDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(review => review.Id == id);
        }

        public async Task<Review> AddAsync(Review passedReview)
        {
            try
            {
                await _context.Reviews.AddAsync(passedReview);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return passedReview;
        }

        public async Task UpdateAsync(Review passedReview)
        {
            var originalReview = await _context.Reviews.FindAsync(passedReview.Id);
            originalReview.Rating = passedReview.Rating;
            originalReview.Body = passedReview.Body;
            originalReview.RestaurantId = passedReview.RestaurantId;
            originalReview.Restaurant = passedReview.Restaurant;
            originalReview.ReviewerName = passedReview.ReviewerName;
            _context.Update(originalReview);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(review => review.Id == id);
            _context.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}