using Microsoft.AspNetCore.Mvc;
using BlogApp.Model;
using BlogApp.Service;
using BlogApp.Facade;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogController()
        {
            _context = new BlogContext();
        }

        // GET
        [HttpGet("GetBlos")]
        public IActionResult GetBlogs()
        {
            BlogFacade blogFacade = new BlogFacade(_context);
            try
            {
                return Ok(blogFacade.GetBlogs());
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al obtener los blogs." + e.Message);
            }
        }

        // GET
        [HttpGet("GetBlogsByCod")]
        public IActionResult GetBlogById(int cod)
        {
            BlogFacade blogFacade = new BlogFacade(_context);
            try
            {
                return blogFacade.GetBlogByCod(cod);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al obtener el blog." + e.Message);
            }
        }

        // POST 
        [HttpPost("SaveBlogs")]
        public IActionResult CreateBlog([FromBody] Blog newBlog)
        {
            BlogFacade blogFacade = new BlogFacade(_context);

            try
            {   
                return blogFacade.CreateBlog(newBlog);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al agregar." + e.Message);
            }
        }

        // PUT
        [HttpPut("UpdateBlogs")]
        public IActionResult UpdateBlog(int cod, [FromBody] Blog updatedBlog)
        {
            BlogFacade blogFacade = new BlogFacade(_context);

            try
            {
                return blogFacade.UpdateBlog(cod, updatedBlog);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al modificar el blog." + e.Message);
            }
        }
    }
}