using System.ComponentModel.DataAnnotations;

namespace BlogApp.Model
{
    public class Book
    {
        [Key] public int COD_BOOK { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public required string Author { get; set; }
        public string State { get; set; }
        public DateTime? Date { get; set; }
    }
}
