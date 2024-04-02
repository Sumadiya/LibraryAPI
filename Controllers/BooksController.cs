using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/{isbn}
        [HttpGet("{isbn}")]
        public async Task<ActionResult<Book>> GetBook(string isbn)
        {
            var book = await _context.Books.FindAsync(isbn);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // PUT: api/Books/{isbn}
        [HttpPut("{isbn}")]
        public async Task<IActionResult> PutBook(string isbn, Book book)
        {
            if (isbn != book.ISBN)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(b => b.ISBN == isbn))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (_context.Books.Any(b => b.ISBN == book.ISBN))
            {
                return BadRequest("ISBN already exists.");
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBook", new { isbn = book.ISBN }, book);
        }

        // DELETE: api/Books/{isbn}
        [HttpDelete("{isbn}")]
        public async Task<IActionResult> DeleteBook(string isbn)
        {
            var book = await _context.Books.FindAsync(isbn);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
