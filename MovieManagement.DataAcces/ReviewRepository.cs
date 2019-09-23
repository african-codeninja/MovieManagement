using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAcces
{
    public class ReviewRepository : BaseRepository
    {
        //get method that return a list view of all reviews
        public List<Review> searchReviews()
        {
            return DbContext.Reviews.ToList();
        }

        //get method
        public Review GetReview(Guid reviewId)
        {
            var review = DbContext.Reviews.FirstOrDefault(a => a.Id == reviewId);
            return review;
        }

        //post method add category
        public void AddReview(Review newReview)
        {
            DbContext.Reviews.Add(newReview);
            DbContext.SaveChanges();
        }

        //delete category method
        public void DeleteReview(Guid reviewId)
        {
            var review = DbContext.Reviews.FirstOrDefault(a => a.Id == reviewId);

            if (review != null)
            {
                DbContext.Reviews.Remove(review);
                DbContext.SaveChanges();
            }

        }

        public void updateReview(Review updatedReview)
        {
            var existingReview = DbContext.Reviews.FirstOrDefault(a => a.Id == updatedReview.Id);
            if (existingReview != null)
            {
                existingReview.Score = updatedReview.Score;
                DbContext.SaveChanges();
            }
        }
    }
}