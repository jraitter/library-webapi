using System;
using System.Collections.Generic;
using library_webapi.Models;
using library_webapi.Repositories;

namespace library_webapi.Services
{
  public class AuthorService
  {
    private readonly AuthorsRepository _repo;
    public AuthorService(AuthorsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Author> Get()
    {
      return _repo.Get();
    }
    public Author Get(int id)
    {
      Author found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    public Author Create(Author newAuthor)
    {
      return _repo.Create(newAuthor);
    }

    public Author Edit(Author updatedAuthor)
    {
      Author exists = _repo.Get(updatedAuthor.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.Edit(updatedAuthor);
    }


    public string Delete(int id)
    {
      Author exists = _repo.Get(id);
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