using Api.Bibiliotheque.Core.Net.Interfaces;
using Api.Bibiliotheque.Core.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Bibiliotheque.Core.Net.Services
{

    public class BookService : IBookService
    {

        private readonly BibliothequeContext _context;
        private readonly ILogger<BookService> _logger;

        public BookService(BibliothequeContext context, ILogger<BookService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<BookModel>> GetBooks()
        {
            var result = await _context.Book.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<BookModel?> GetBook(int id)
        {
            var result = await _context.Book.AsNoTracking().Where(book=>book.Id==id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<BookModel> AddBook(BookModel book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
            _context.Entry(book).State = EntityState.Detached;

            return book;
        }

        public async Task<BookModel?> UpdateBook(int id, BookModel book)
        {
            if (book.Id != id)
            {
                _logger.LogError("Le livre que vous voulez modifier n'est pas correct");
                return null;
            }

            var result = await _context.Book.AsNoTracking().Where(book => book.Id == id).FirstOrDefaultAsync();
            if (result == null)
                return null;

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(book).State = EntityState.Detached;

            _logger.LogWarning($"Enregistrement modifié avec succès : {book.Title}");

            return book;
        }

        public async Task<BookModel?> DeleteBook(int id)
        {
            var result = await _context.Book.FindAsync(id);
            if (result == null)
                return null;

            _context.Book.Remove(result);
            await _context.SaveChangesAsync();
            _context.Entry(result).State = EntityState.Detached;

            return (result);
        }


    }
}
