namespace BlogApp.Connection
{
    public static class ConnectionDB
    {
        private static string connectionString = string.Empty;

        public static string getSQLString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;

            if (connectionString == null)
            {
                throw new Exception("Connection string invalido");
            }

            return connectionString;
        }
    }
}
