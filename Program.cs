using System.Security.Cryptography.X509Certificates;

namespace MovieAppTask
{
    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Horror,
        Scifi,
        Romance,
        Documentary,
        Detective,
        Sport
    }
    internal class Program
    {
        

        static void Main(string[] args)
        {
            var manager = new MovieManager();
            
            while (true)
            {
                Console.WriteLine("\n--- Movie Manager ---");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Show All Movies");
                Console.WriteLine("3. Mark as Watched");
                Console.WriteLine("4. Mark as Unwatched");
                Console.WriteLine("5. Play Movie");
                Console.WriteLine("6. Stop Movie");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter a Year: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Enter a genre: ");
                        Genre genre = Enum.Parse<Genre>(Console.ReadLine(), true);

                        var movie = new Movie(title, year, genre);
                        manager.Add(movie);
                        break;

                    case "2":
                        manager.Show();
                        break;

                    case "3":
                        Console.Write("Enter movie to mark as watched: ");
                        title = Console.ReadLine();
                        var movies = manager.GetAll();
                        var m1 = movies.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                        if (m1 != null) m1.MarkAsWatched();
                        else Console.WriteLine("Movie not found.");
                        break;

                    case "4":
                        Console.Write("enter movie title to mark as unwatched: ");
                        title = Console.ReadLine();
                        var movies2 = manager.GetAll();
                        var m2 = movies2.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                        if (m2 != null) m2.MarkAsUnwatched();
                        else Console.WriteLine("Movie not found");
                        break;

                    case "5":
                        Console.Write("Enter Movie title to play: ");
                        title = Console.ReadLine();
                        var m3 = manager.GetAll().Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                        if (m3 != null) m3.Play();
                        else Console.WriteLine("Movie not found.");
                        break;

                    case "6":
                        Console.Write("Enter Movie title to stop: ");
                        title = Console.ReadLine();
                        var m4 = manager.GetAll().Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                        if (m4 != null) m4.Play();
                        else Console.WriteLine("Movie not found");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;

                }
            }
        }
    }
}
