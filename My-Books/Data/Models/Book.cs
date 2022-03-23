using My_Books.Data.Models;

namespace My_Books.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool isRead { get; set; }
        public DateTime? dateRead { get; set; }
        public int? rate { get; set; }
        public DateTime dateAdded { get; set; }
        public int publisherId { get; set; }
        public Publisher publisher { get; set; }
        public List<Book_Author> book_Authors { get; set; }

    }
}
