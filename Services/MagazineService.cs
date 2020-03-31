using System;
using System.Collections.Generic;
using library_webapi.Models;
using library_webapi.Repositories;

namespace library_webapi.Services
{
  public class MagazineService
  {
    private readonly MagazinesRepository _repo;
    public MagazineService(MagazinesRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Magazine> Get()
    {
      return _repo.Get();
    }
    public Magazine Get(int id)
    {
      Magazine found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    public Magazine Create(Magazine newMagazine)
    {
      return _repo.Create(newMagazine);
    }

    public Magazine Edit(Magazine updatedMagazine)
    {
      Magazine exists = _repo.Get(updatedMagazine.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.Edit(updatedMagazine);
    }

    public Magazine CheckOut(Magazine updatedMagazine)
    {
      Magazine exists = _repo.Get(updatedMagazine.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.CheckOut(updatedMagazine);
    }

    public string Delete(int id)
    {
      Magazine exists = _repo.Get(id);
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