using MovieManagement.DataAcces;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.ManageMent
{
    public class ReviewManagement
    {
        private ReviewRepository _reviewrepo = new ReviewRepository();
        public List<ReviewDTO> Search()
        {
            var result = _reviewrepo.searchReviews();

            var toresult = result.Select(a => new ReviewDTO
            {                
                Id = a.Id,
                Score = a.Score
            }).ToList();
            return toresult;
        }
        public ReviewDTO GetReview(Guid reviewid)
        {
            var result = _reviewrepo.GetReview(reviewid);
            return new ReviewDTO
            {
                Id = result.Id,
                Score = result.Score                
            };
        }

        public void DelReview(Guid reviewid)
        {
            _reviewrepo.DeleteReview(reviewid);
        }

        public void AddorUpdateReview(ReviewDTO review)
        {
            var reviewed = new Review()
            {
                Id = review.Id!=Guid.Empty ? review.Id : Guid.NewGuid(),
                Score = review.Score
            };

            if (review.Id != Guid.Empty)
            {
                //update
                _reviewrepo.updateReview(reviewed);
            }

            else
            {
                _reviewrepo.AddReview(reviewed);
            }
        }
    }
}
