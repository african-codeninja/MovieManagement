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
        //This is declared with a private access modifier as it is going to be used only in side this class
        private MovieRepository _repo = new MovieRepository();
        //Serach list
        public List<MovieDTO> search()
        {
            
            var result =_repo.searchMovies();

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
        public MovieDTO GetMovie (Guid id)
        {
            var repoResult = _repo.GetMovie(id);
            return new MovieDTO
            {
                Id = repoResult.Id,
                AverageScore = (float)repoResult.AverageScore,
                CategoryName = repoResult.Category.Name,
                Length = repoResult.Length,
                Rating = repoResult.Rating,
                ReleaseDate = repoResult.ReleaseDate,
                Title = repoResult.Title

            };
        }

        public void DeleteMovie(Guid id)
        {
            _repo.DeleteMovie(id);
        }

        public void AddorUpdate(MovieDTO movie)
        {
            
            var movy = new Movie
            {
                Id = movie.Id!=Guid.Empty ? movie.Id: Guid.NewGuid(), //inline if
                Title = movie.Title,
                AverageScore = movie.AverageScore,
                Length = movie.Length,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate
            };
 
            if (!string.IsNullOrEmpty(movie.CategoryName))
            {
                var categoryRepo = new CategoryRepository();
                var existingCategory = categoryRepo.GetCategorybyName(movie.CategoryName);
                if (existingCategory != null)
                {
                    movy.CategoryId = existingCategory.Id;
                }
            }

            if (movie.Id != Guid.Empty)//movie exists => update
            {
                _repo.updateMovie(movy);
            }

            else//movie doesn't exist => add
            {
                _repo.AddMovie(movy);
            }
        }
    }
}
