using System.Collections.Generic;
using System.Data;
using Dapper;
using library_webapi.Models;

namespace library_webapi.Repositories
{
  public class AuthorsRepository
  {
    private readonly IDbConnection _db;

    public AuthorsRepository(IDbConnection db)
    {
      _db = db;
    }

    //Get
    public IEnumerable<Author> Get()
    {
      string sql = "SELECT * FROM authors";
      return _db.Query<Author>(sql);
    }

    // Get by id
    public Author Get(int Id)
    {
      string sql = "SELECT * FROM authors WHERE id=@Id";
      return _db.QueryFirstOrDefault<Author>(sql, new { Id });
    }

    // Post
    public Author Create(Author newAuthor)
    {
      string sql = @"
      INSERT INTO authors (name, publication)
      VALUES (@Name, @Publication);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newAuthor);
      newAuthor.Id = id;
      return newAuthor;
    }

    // Put 
    public Author Edit(Author updatedAuthor)
    {
      string sql = @"
  UPDATE authors SET
  name = @Name,
  publication = @Publication,
  WHERE id =@Id;
  ";
      _db.Execute(sql, updatedAuthor);
      return updatedAuthor;
    }

    // Delete
    public bool Delete(int Id)
    {
      string sql = @"
      DELETE FROM authors WHERE id=@Id LIMIT 1";
      int changed = _db.Execute(sql, new { Id });
      return changed == 1;
    }
  }//endof class
}//endof namespace