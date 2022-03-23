namespace My_Books.Data.Models
{
    public class AuthorVM
    {
        public string name { get; set; }
    }
    public class AuthorWithBooksVM
    {
        public string name { get; set; }
        public List<string> Books { get; set; }
    }
}
