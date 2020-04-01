using System;
using library_webapi.Models;
using library_webapi.Repositories;

namespace library_webapi.Services
{
  public class BookAuthorService
  {
    private readonly BookAuthorsRepository _repo;
    public BookAuthorService(BookAuthorsRepository repo)
    {
      _repo = repo;
    }

    // internal BookAuthor Get(int id)
    // {
    //     BookAuthor found = _repo.Get(id);
    //     if (found == null)
    //     {
    //         throw new Exception("Invalid Id");
    //     }
    //     return found;
    // }

    internal BookAuthor Create(BookAuthor newBookAuthor)
    {
      BookAuthor created = _repo.Create(newBookAuthor);
      if (created == null)
      {
        throw new Exception("Create Request Failed");
      }
      return created;
    }
    internal String Delete(BookAuthor ba)
    {
      if (_repo.Delete(ba))
      {
        return "Successfully Deleted";
      }
      throw new Exception("Invalid Id");
    }
  }
}