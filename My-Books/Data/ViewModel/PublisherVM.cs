using My_Books.Data.ViewModel;
using My_Books.Models;

namespace My_Books.Data.Models
{
    public class PublisherVM
    {
        public string name { get; set; }
    }
    public class PublisherWithBookAndAuthorVM
    {
        public string name { get; set; }
        public List<BookWithAuthorVM> books { get; set; }
    }
}
