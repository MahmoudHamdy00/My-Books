using My_Books.Data.Models;

namespace My_Books.Data.ViewModel
{
    public class BookVM
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool isRead { get; set; }
        public DateTime? dateRead { get; set; }
        public int? rate { get; set; }
        public int publisherId { get; set; }
        public List<int> authorsId { get; set; }
    }
    public class BookWithAuthorVM
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool isRead { get; set; }
        public DateTime? dateRead { get; set; }
        public int? rate { get; set; }
        public string publisherName { get; set; }
        public List<string> authorsNames { get; set; }
    }
}
