using BlogApp.Model;
using Microsoft.EntityFrameworkCore;
using BlogApp.Connection;

namespace BlogApp.Service
{
    // Contexto de base de datos utilizando EF Core
    public class BlogContext : DbContext
    {
        public DbSet<Book> BOOK { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionDB.getSQLString()); // Configuro string conection
        }
    }
}
