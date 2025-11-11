using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppTask
{
    public abstract class Media
    {
        public string Title {  get; set; }
        public int Year {  get; set; }

        protected Media(string title, int year)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title can not be empty.");
            }
            if (year < 0)
            {
                throw new ArgumentException("Year can not be negative.");
            }

            Title = title;
            Year = year;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Year: {Year}");
        }
    }
}
