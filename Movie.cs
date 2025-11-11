using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppTask
{
    public class Movie : Media, IPlayable
    {
        public Genre Genre { get; set; }
        public bool Watched { get; set; }

        private static readonly string FilePath = "Data/movie.json";

        public Movie(string title, int year, Genre genre, bool watched = false) : base(title, year) 
        {
            Genre = genre;
            Watched = watched;
        }

        public void Play()
        {
            Console.WriteLine($"Playing {Title} . . . ");
        }

        public void Stop()
        {
            Console.WriteLine($"Movie {Title} has stopped.");
        }

        public void MarkAsWatched()
        {
            Watched = true;
            UpdateInJson();
        }

        public void MarkAsUnwatched()
        {
            Watched = false;
            UpdateInJson();

        }

        private void UpdateInJson()
        {
            var manager = new Services.MovieManager();
            manager.UpdateMovie(this);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Year: {Year}, Genre: {Genre}, Watched: {Watched}");
        }
    }
    
}
