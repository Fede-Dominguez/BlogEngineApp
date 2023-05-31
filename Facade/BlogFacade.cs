using BlogApp.Model;
using BlogApp.Helper;
using BlogApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Facade
{
    public class BlogFacade : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogFacade(BlogContext context)
        {
            _context = context;
        }

        public IActionResult GetBooks()
        {
            return Ok(_context.BOOK.ToList() ?? throw new Exception("No hay libros en el blog."));
        }

        public IActionResult GetBookByCod(int cod)
        {
            return Ok(_context.BOOK.FirstOrDefault(blog => blog.COD_BOOK == cod) ?? throw new Exception("Libro inexistente."));
        }

        public IActionResult CreateBook(Book newBook)
        {
            if (!ValidationHelper.ValidateForPost(newBook))
            {
                return BadRequest("Datos de libro inválidos.");
            }

            newBook.COD_BOOK = 0;
            newBook.State = "Pending";

            _context.BOOK.Add(newBook);
            _context.SaveChanges();

            return Ok("Libro creado exitosamente.");
        }

        public IActionResult UpdateBook(int cod, Book updatedBlog)
        {
            if (!ValidationHelper.ValidateForPut(updatedBlog))
            {
                return BadRequest("Datos del libro inválidos.");
            }

            Book? existingBlog = _context.BOOK.FirstOrDefault(blog => blog.COD_BOOK == cod);

            if (existingBlog == null)
            {
                return NotFound("Libro no encontrado.");
            }

            existingBlog.Title = updatedBlog.Title;
            existingBlog.Description = updatedBlog.Description;
            existingBlog.State = updatedBlog.State;
            existingBlog.Author = updatedBlog.Author;
            existingBlog.Date = updatedBlog.Date;

            _context.SaveChanges();

            return Ok("Libro actualizado exitosamente.");
        }
    }
}
