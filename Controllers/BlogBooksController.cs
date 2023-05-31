using Microsoft.AspNetCore.Mvc;
using BlogApp.Model;
using BlogApp.Service;
using BlogApp.Facade;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogBooksController : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogBooksController()
        {
            _context = new BlogContext();
        }

        // GET
        [HttpGet("GetBooks")]
        public IActionResult GetBooks()
        {
            BlogFacade blogFacade = new BlogFacade(_context);
            try
            {
                return Ok(blogFacade.GetBooks());
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al obtener los libros." + e.Message);
            }
        }

        // GET
        [HttpGet("GetBooksByCod")]
        public IActionResult GetBlogById(int cod)
        {
            BlogFacade blogFacade = new BlogFacade(_context);
            try
            {
                return blogFacade.GetBookByCod(cod);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al obtener el libro." + e.Message);
            }
        }

        // POST 
        [HttpPost("SaveBooks")]
        public IActionResult CreateBlog([FromBody] Book newBook)
        {
            BlogFacade blogFacade = new BlogFacade(_context);

            try
            {   
                return blogFacade.CreateBook(newBook);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al agregar." + e.Message);
            }
        }

        // PUT
        [HttpPut("UpdateBooks")]
        public IActionResult UpdateBlog(int cod, [FromBody] Book updatedBook)
        {
            BlogFacade blogFacade = new BlogFacade(_context);

            try
            {
                return blogFacade.UpdateBook(cod, updatedBook);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al modificar el libro." + e.Message);
            }
        }
    }
}