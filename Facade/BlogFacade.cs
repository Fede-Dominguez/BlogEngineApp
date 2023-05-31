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

        public IActionResult GetBlogs()
        {
            return Ok(_context.BLOG.ToList().Where(p => p.State == "Pending") ?? throw new Exception("No hay blogs disponibles."));
        }

        public IActionResult GetBlogByCod(int cod)
        {
            return Ok(_context.BLOG.FirstOrDefault(p => p.COD_BLOG == cod && p.State == "Pending") ?? throw new Exception("Blog inexistente."));
        }

        public IActionResult CreateBlog(Blog newBlog)
        {
            if (!ValidationHelper.ValidateForPost(newBlog))
            {
                return BadRequest("Datos del blog inválidos.");
            }

            newBlog.COD_BLOG = 0;
            newBlog.State = "Pending";

            _context.BLOG.Add(newBlog);
            _context.SaveChanges();

            return Ok("Blog creado exitosamente.");
        }

        public IActionResult UpdateBlog(int cod, Blog updatedBlog)
        {
            if (!ValidationHelper.ValidateForPut(updatedBlog))
            {
                return BadRequest("Datos del blog inválidos.");
            }

            Blog? existingBlog = _context.BLOG.FirstOrDefault(p => p.COD_BLOG == cod);

            if (existingBlog == null)
            {
                return NotFound("Blog no encontrado.");
            }

            existingBlog.Title = updatedBlog.Title;
            existingBlog.Description = updatedBlog.Description;
            existingBlog.State = updatedBlog.State;
            existingBlog.Author = updatedBlog.Author;
            existingBlog.Date = updatedBlog.Date;

            _context.SaveChanges();

            return Ok("Blog actualizado exitosamente.");
        }
    }
}
