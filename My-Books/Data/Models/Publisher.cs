using My_Books.Models;

namespace My_Books.Data.Models
{
    public class Publisher
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Book> books { get; set; }
    }
}
