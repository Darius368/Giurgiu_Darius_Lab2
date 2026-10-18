using System.Collections.Generic;

namespace Nume_Pren_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }

        public string PublisherName { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}