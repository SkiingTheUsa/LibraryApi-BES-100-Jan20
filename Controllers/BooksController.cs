using LibraryApi.Domain;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class BooksController : Controller
    {
        LibraryDataContext Context;

        public BooksController(LibraryDataContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("/books")]
        public async Task<IActionResult> GetAllBooks([FromQuery] string genre = "all")
        {

            var response = new GetBooksResponseCollection();

            var allBooks = Context.Books.Select(b => new BookSummaryItem
            {
                Id = b.Id,
                Author = b.Author,
                Genre = b.Genre,
                Title = b.Title
            });

            if (genre != "all")
            {
                allBooks = allBooks.Where(b => b.Genre == genre);
            };

            response.Books = await allBooks.ToListAsync();

            return Ok(response);
        }

    }
}
