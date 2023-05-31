using BlogApp.Model;

namespace BlogApp.Helper
{
    public static class ValidationHelper
    {
        public static bool ValidateForPost(Blog blog)
        {
            if (string.IsNullOrWhiteSpace(blog.Title))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(blog.Author))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateForPut(Blog blog)
        {
            if (string.IsNullOrWhiteSpace(blog.Title))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(blog.Author))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(blog.State) || (blog.State != "Pending" || blog.State != "Published"))
            {
                return false;
            }

            return true;
        }
    }
}
