using System.Data;
using Dapper;
using library_webapi.Models;

namespace library_webapi.Repositories
{
  public class BookAuthorsRepository
  {
    private readonly IDbConnection _db;

    public BookAuthorsRepository(IDbConnection db)
    {
      _db = db;
    }//endof constructor

    // internal BookAuthor Get(int Id)
    // {
    //     string sql = "SELECT * FROM bookauthors WHERE id = @Id";
    //     // NOTE essentialy FindOne() returns a single object or null
    //     return _db.QueryFirstOrDefault<BookAuthor>(sql, new { Id });
    // }

    internal BookAuthor Create(BookAuthor newBookAuthor)
    {
      string sql = @"
            INSERT INTO bookauthors
            (bookId, authId)
            VALUES
            (@BookId, @AuthId);
            SELECT LAST_INSERT_ID();
            ";
      newBookAuthor.Id = _db.ExecuteScalar<int>(sql, newBookAuthor);
      return newBookAuthor;
    }

    internal bool Delete(BookAuthor cs)
    {
      string sql = "DELETE FROM bookauthors WHERE bookId = @BookId AND authId = @AuthId LIMIT 1";
      int deleted = _db.Execute(sql, cs);
      return deleted == 1;
    }


  }//endof class
}//endof namespace