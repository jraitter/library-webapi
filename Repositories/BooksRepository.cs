using System.Collections.Generic;
using System.Data;
using Dapper;
using library_webapi.Models;

namespace library_webapi.Repositories
{
  public class BooksRepository
  {
    private readonly IDbConnection _db;

    public BooksRepository(IDbConnection db)
    {
      _db = db;
    }

    //Get
    public IEnumerable<Book> Get()
    {
      string sql = "SELECT * FROM books";
      return _db.Query<Book>(sql);
    }

    // Get by id
    public Book Get(int Id)
    {
      string sql = "SELECT * FROM books WHERE id=@Id";
      return _db.QueryFirstOrDefault<Book>(sql, new { Id });
    }

    // Post
    public Book Create(Book newBook)
    {
      string sql = @"
      INSERT INTO books (title, author, libId, available)
      VALUES (@Title, @Author, @LibId, true);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newBook);
      newBook.Id = id;
      newBook.Available = true;
      return newBook;
    }

    // Put 
    public Book Edit(Book updatedBook)
    {
      string sql = @"
  UPDATE books SET
  title = @Title,
  author = @Author,
  available = @Available,
  libId = @LibId
  WHERE id =@Id;
  ";
      _db.Execute(sql, updatedBook);
      return updatedBook;
    }

    public Book CheckOutIn(Book updatedBook)
    {
      string sql = @"
  UPDATE books SET
  available = @Available
  WHERE id =@Id;
  ";
      _db.Execute(sql, updatedBook);
      return updatedBook;
    }

    // Delete
    public bool Delete(int Id)
    {
      string sql = @"
      DELETE FROM books WHERE id=@Id LIMIT 1";
      int changed = _db.Execute(sql, new { Id });
      return changed == 1;
    }


  }//endof class
}//endof namespace