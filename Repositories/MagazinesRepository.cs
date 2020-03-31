using System.Collections.Generic;
using System.Data;
using Dapper;
using library_webapi.Models;

namespace library_webapi.Repositories
{
  public class MagazinesRepository
  {
    private readonly IDbConnection _db;

    public MagazinesRepository(IDbConnection db)
    {
      _db = db;
    }

    //Get
    public IEnumerable<Magazine> Get()
    {
      string sql = "SELECT * FROM magazines";
      return _db.Query<Magazine>(sql);
    }

    // Get by id
    public Magazine Get(int Id)
    {
      string sql = "SELECT * FROM magazines WHERE id=@Id";
      return _db.QueryFirstOrDefault<Magazine>(sql, new { Id });
    }

    // Post
    public Magazine Create(Magazine newMagazine)
    {
      string sql = @"
      INSERT INTO magazines (title, publisher, volume, available)
      VALUES (@Title, @Publisher, @Volume, true);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newMagazine);
      newMagazine.Id = id;
      newMagazine.Available = true;
      return newMagazine;
    }

    // Put 
    public Magazine Edit(Magazine updatedMagazine)
    {
      string sql = @"
  UPDATE magazines SET
  title = @Title,
  publisher = @Publisher,
  volume = @Volume,
  available = @Available
  WHERE id =@Id;
  ";
      _db.Execute(sql, updatedMagazine);
      return updatedMagazine;
    }

    public Magazine CheckOut(Magazine updatedMagazine)
    {
      string sql = @"
  UPDATE magazines SET
  available = @Available
  WHERE id =@Id;
  ";
      _db.Execute(sql, updatedMagazine);
      return updatedMagazine;
    }

    // Delete
    public bool Delete(int Id)
    {
      string sql = @"
      DELETE FROM magazines WHERE id=@Id LIMIT 1";
      int changed = _db.Execute(sql, new { Id });
      return changed == 1;
    }


  }//endof class
}//endof namespace