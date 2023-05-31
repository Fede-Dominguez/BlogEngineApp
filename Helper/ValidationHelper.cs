using BlogApp.Model;
using System.Reflection.Metadata;

namespace BlogApp.Helper
{
    public static class ValidationHelper
    {
        public static bool ValidateForPost(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(book.Author))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateForPut(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(book.Author))
            {
                return false;
            }

            return true;
        }
    }
}
