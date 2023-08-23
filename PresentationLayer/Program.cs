using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Core.Types;
using SelfProjectDataAccess.Interfaces;
using SelfProjectDataAccess.Models;
using SelfProjectDataAccess.Repositories;
using System;

namespace PresentationLayer
{
    internal class Program
    {
        SelfProjectContext _context;
        IMovieRepository movieRepository;

        public Program(IMovieRepository movieRepository, SelfProjectContext context)
        {
            this.movieRepository = movieRepository;
            this._context = context;
        }
        static void Main(string[] args)
        {
            var service = new ServiceCollection();
            service.AddTransient<Program>();
            service.AddSingleton<IMovieRepository, MovieRepository>();
            service.AddSingleton<SelfProjectContext>();
            using (var scope = service.BuildServiceProvider())
            {
                Program app = scope.GetRequiredService<Program>();
                app.Run();
            }
        }

        private void Run()
        {
            var movies = movieRepository.GetAll();
            foreach (var movie in movies)
            {
                Console.WriteLine($"Movie: {movie.Title}");
                foreach (var genre in movie.Genres)
                {
                    Console.WriteLine($"Genre: {genre.GenreName}");
                }
                Console.WriteLine("");
            }
        }
    }
}