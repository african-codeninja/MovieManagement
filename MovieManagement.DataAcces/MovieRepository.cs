using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAcces
{
    public class MovieRepository : BaseRepository
    {
        public List<Movie> searchMovies()
        {
            return DbContext.Movies.ToList();
        }
        //get method
        public Movie GetMovie(Guid movieId)
        {
            var movie = DbContext.Movies.FirstOrDefault(a => a.Id == movieId);
            return movie;
        }

        //post method add category
        public void AddMovie(Movie newMovie)
        {
            DbContext.Movies.Add(newMovie);
            DbContext.SaveChanges();
        }

        //delete category method
        public void DeleteMovie(Guid movieId)
        {
            var movie = DbContext.Movies.FirstOrDefault(a => a.Id == movieId);

            if (movie != null)
            {
                DbContext.Movies.Remove(movie);
                DbContext.SaveChanges();
            }
        }

        public void updateMovie(Movie updatedMovie)
        {
            var existingMovie = DbContext.Movies.FirstOrDefault(a => a.Id == updatedMovie.Id);

            if (existingMovie != null)
            {
                existingMovie.Title = updatedMovie.Title;
                existingMovie.Rating = updatedMovie.Rating;
                existingMovie.Rating = updatedMovie.Rating;
                DbContext.SaveChanges();
            }
        }
    }
}
