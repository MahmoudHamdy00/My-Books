using My_Books.Data.Models;
using My_Books.Data.ViewModel;
using My_Books.Models;

namespace My_Books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        public void AddBook(BookVM book)
        {
            var _Book = new Book()
            {
                title = book.title,
                description = book.description,
                isRead = book.isRead,
                dateRead = book.isRead ? book.dateRead : null,
                rate = book.isRead ? book.rate : null,
                dateAdded = DateTime.Now,
                publisherId = book.publisherId
            };
            _context.Books.Add(_Book);
            _context.SaveChanges();
            foreach (int id in book.authorsId)
            {
                _context.book_Authors.Add(new Book_Author()
                {
                    bookId = _Book.id,
                    authorId = id
                });
            }
            _context.SaveChanges();
        }
        public BookWithAuthorVM GetBookByID(int id)
        {
            return _context.Books.Where(book => book.id == id).Select(book => new BookWithAuthorVM()
            {
                title = book.title,
                description = book.description,
                isRead = book.isRead,
                dateRead = book.dateRead,
                rate = book.rate,
                publisherName = book.publisher.name,
                authorsNames = book.book_Authors.Select(y => y.author.name).ToList(),
            }).FirstOrDefault();
        }
        /*public Book GetBookByAuthor(int AuthorId)
        {
            return _context.Books.FirstOrDefault(x => x.aut == id);
        }*/
        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public void deleteBookById(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();

            }
        }
        public void updateBookById(int id, BookVM book)
        {
            Book _book = _context.Books.FirstOrDefault(x => x.id == id);
            if (_book != null)
            {
                _book.title = book.title;
                _book.description = book.description;
                _book.isRead = book.isRead;
                _book.dateRead = book.dateRead;
                _book.rate = book.rate;
                _context.SaveChanges();
            }
        }
    }
}
