using System;
using System.Collections.Generic;
using library_webapi.Models;
using library_webapi.Repositories;

namespace library_webapi.Services
{
  public class BookService
  {
    private readonly BooksRepository _repo;
    public BookService(BooksRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Book> GetBooksByAuthId(int authId)
    {
      return _repo.GetBooksByAuthId(authId);
    }
    public IEnumerable<Book> Get()
    {
      return _repo.Get();
    }
    public Book Get(int id)
    {
      Book found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    public Book Create(Book newBook)
    {
      return _repo.Create(newBook);
    }

    public Book Edit(Book updatedBook)
    {
      Book exists = _repo.Get(updatedBook.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.Edit(updatedBook);
    }

    public Book CheckOut(Book updatedBook)
    {
      Book exists = _repo.Get(updatedBook.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.CheckOutIn(updatedBook);
    }

    public string Delete(int id)
    {
      Book exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      //if you are the creator
      if (_repo.Delete(id))
      {
        return "Success";
      }
      throw new Exception("Something went wrong with deleting that item");
    }
  }//endof class
}//endof namespace