using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAppTask
{
    public class MovieManager
    {
        private readonly string filePath = "Data/movie.json";

        public MovieManager()
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory("Data");
                File.WriteAllText(filePath, "[]");
            } 
        }

        public void Add(Movie movie)
        {
            var movies = GetAll();
            movies.Add(movie);
            SaveAll(movies);
            Console.WriteLine($"{movie.Title} added successfully");
        }

        public void Show()
        {
            var movies = GetAll();
            Console.WriteLine("\n---- Movie List ----");
            foreach (var movie in movies)
            {
                movie.DisplayInfo();
            }
        }

        public List<Movie> GetAll()
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        public void SaveAll(List<Movie> movies)
        {
            var json = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(filePath, json);
        }

        public void UpdateMovie(Movie updatedMovie)
        {
            var movies = GetAll();
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Title == updatedMovie.Title)
                {
                    movies[i] = updatedMovie;
                    break;
                }
            }
            SaveAll(movies);

        }
    }
}
