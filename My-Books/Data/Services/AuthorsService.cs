using My_Books.Data.Models;
using My_Books.Data.ViewModel;
using My_Books.Models;

namespace My_Books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                name = author.name
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
        public AuthorWithBooksVM GetAuthorByID(int id)
        {
            return _context.Authors.Where(x => x.id == id).Select(author => new AuthorWithBooksVM()
            {
                name = author.name,
                Books = author.book_Authors.Select(x => x.book.title).ToList()
            }).FirstOrDefault();
        }

        public List<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public void deleteAuthorById(int id)
        {
            Author _author = _context.Authors.FirstOrDefault(x => x.id == id);
            if (_author != null)
            {
                _context.Authors.Remove(_author);
                _context.SaveChanges();

            }
        }
        public void updateAuthorById(int id, AuthorVM author)
        {
            Author _author = _context.Authors.FirstOrDefault(x => x.id == id);
            if (_author != null)
            {
                _author.name = author.name;
                _context.SaveChanges();
            }
        }
    }
}
