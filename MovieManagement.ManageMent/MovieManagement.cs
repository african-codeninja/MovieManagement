using MovieManagement.DataAcces;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.ManageMent
{
    public class MovieManagement
    {
        //Serach list
        public List<MovieDTO> search()
        {
            var repo = new MovieRepository();
            var result = repo.searchMovies();

            var toReturn = result.Select(a => new MovieDTO
            {
                Id = a.Id,
                AverageScore = (float)a.AverageScore,
                CategoryName = a.Category.Name,
                Length = a.Length,
                Rating = a.Rating,
                ReleaseDate = a.ReleaseDate,
                Title = a.Title
            }).ToList();
            return toReturn;
        }

        //Get Method
        public MovieDTO GetMovie(Guid id)
        {
            var repo = new 
        }
    }
}
