using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GimcheonLibrary.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace GimcheonLibrary.DataAccess.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly string _connectionString;
        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgresConnection");
        }
        internal IDbConnection Connection => new NpgsqlConnection(_connectionString);


        public void Add(Book item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO books (title,author,description,\"totalCopies\",\"availableCopies\",\"imageUrl\") " +
                                     "VALUES(@Title,@Author,@Description,@TotalCopies,@AvailableCopies,@ImageUrl)", item);
            }
        }
        public IEnumerable<Book> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Book>("SELECT * FROM books");
            }
        }
        public Book FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Book>("SELECT * FROM books WHERE id = @Id", new { id }).FirstOrDefault();
            }
        }
        public void Update(Book item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE books SET title = @Title, author = @Author, description = @Description, " +
                                   "\"totalCopies\" = @TotalCopies, \"availableCopies\" = @AvailableCopies, \"imageUrl\" = @ImageUrl WHERE id = @Id", item);
            }
        }
        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM books WHERE id=@Id", new { id });
            }
        }
    }
}
