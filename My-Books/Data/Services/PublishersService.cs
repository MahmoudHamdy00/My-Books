using My_Books.Data.Models;
using My_Books.Data.Paging;
using My_Books.Data.ViewModel;
using My_Books.Exceptions;
using My_Books.Models;
using System.Text.RegularExpressions;

namespace My_Books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            if (startWithNum(publisher.name)) throw new InvalidNameException("start With num", publisher.name);
            var _publisher = new Publisher()
            {
                name = publisher.name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
        public PublisherWithBookAndAuthorVM GetPublisherByID(int id)
        {
            var _publisher = _context.Publishers.Where(x => x.id == id).Select(x => new PublisherWithBookAndAuthorVM()
            {
                name = x.name,
                books = x.books.Select(y => new BookWithAuthorVM()
                {
                    title = y.title,
                    authorsNames = y.book_Authors.Select(x => x.author.name).ToList()
                }).ToList()
            }).FirstOrDefault();
            if (null != _publisher)
                return _publisher;
            return null;
        }
        public List<Publisher> GetPublishers(int? pageIndex)
        {

            var publishers = _context.Publishers.ToList();
            publishers = PaginatedList<Publisher>.create(publishers.AsQueryable(), pageIndex ?? 1, 5);
            return publishers;
        }

        public void deletePublisherById(int id)
        {
            Publisher publisher = _context.Publishers.FirstOrDefault(x => x.id == id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();

            }
        }
        public void updatePublisherById(int id, PublisherVM publisher)
        {
            Publisher _publisher = _context.Publishers.FirstOrDefault(x => x.id == id);
            if (_publisher != null)
            {
                _publisher.name = publisher.name;

                _context.SaveChanges();
            }
        }
        private bool startWithNum(string name)
        {
            return Regex.IsMatch(name, @"^\d");
        }
    }
}
