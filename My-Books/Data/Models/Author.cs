namespace My_Books.Data.Models
{
    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Book_Author> book_Authors { get; set; }
    }
}
