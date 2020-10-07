using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GimcheonLibrary.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace GimcheonLibrary.DataAccess.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly string _connectionString;
        public AuthorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgresConnection");
        }
        internal IDbConnection Connection => new NpgsqlConnection(_connectionString);


        public void Add(Author item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO authors (name,about,books) VALUES (@Name,@About,@Books)", item);
            }
        }

        public IEnumerable<Author> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
               return dbConnection.Query<Author>("SELECT * FROM authors");
            }
        }

        public Author FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Author>("SELECT * FROM authors WHERE id = @Id", new { id }).FirstOrDefault();
            }
        }

        public void Update(Author item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE authors SET name = @Name, about = @About, books = @Books, WHERE id = @Id", item);
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
