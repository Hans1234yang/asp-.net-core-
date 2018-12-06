using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoModel;

namespace yangxu1.Service
{
    public class MovieService : IMovieService
    {

        private readonly List<Movie> _movie = new List<Movie>();

        public MovieService()
        {
            _movie.Add(new Movie
            {
                CinemaId=1,
                Name="泰坦尼克号",
                ReleaseDate=DateTime.Now,
                Starring="jack"
            });

            _movie.Add(new Movie
            {
                CinemaId=2,
                Name="卧虎藏龙",
                ReleaseDate=DateTime.Now,
                Starring="tony"             
            });

            _movie.Add(new Movie
            {
                CinemaId=3,
                Name="英雄",
                ReleaseDate=DateTime.Now,
                Starring="jenny"
            });
        }

        public Task AddAsync(Movie model)
        {
            var maxId = _movie.Max(x=>x.Id);

            model.Id = maxId + 1;
            _movie.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            return Task.Run(()=>  _movie.Where(x=>x.CinemaId==cinemaId));
        }
    }
}
