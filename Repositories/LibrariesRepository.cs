using System.Collections.Generic;
using System.Data;
using Dapper;
using library_webapi.Models;

namespace library_webapi.Repositories
{
  public class LibrariesRepository
  {
    private readonly IDbConnection _db;

    public LibrariesRepository(IDbConnection db)
    {
      _db = db;
    }

    //Get
    public IEnumerable<Library> Get()
    {
      string sql = "SELECT * FROM libraries";
      return _db.Query<Library>(sql);
    }

    // Get by id
    public Library Get(int Id)
    {
      string sql = "SELECT * FROM libraries WHERE id=@Id";
      return _db.QueryFirstOrDefault<Library>(sql, new { Id });
    }

    // Post
    public Library Create(Library newLibrary)
    {
      string sql = @"
      INSERT INTO libraries (name, location)
      VALUES (@Name, @Location);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newLibrary);
      newLibrary.Id = id;
      return newLibrary;
    }

    // Put 
    public Library Edit(Library updatedLibrary)
    {
      string sql = @"
  UPDATE libraries SET
  name = @Name,
  location = @Location
  WHERE id =@Id;
  ";
      _db.Execute(sql, updatedLibrary);
      return updatedLibrary;
    }

    // Delete
    public bool Delete(int Id)
    {
      string sql = @"
      DELETE FROM libraries WHERE id=@Id LIMIT 1";
      int changed = _db.Execute(sql, new { Id });
      return changed == 1;
    }
  }//endof class
}//endof namespace