using System;
using System.Collections.Generic;
using library_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_webapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MagazinesController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Magazine>> Get()
    {
      try
      {
        return Ok(FakeDB.magazines);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof Get

    [HttpGet("{magazineId}")]
    public ActionResult<Magazine> GetByID(string magazineId)
    {
      try
      {
        Magazine magazineFound = FakeDB.magazines.Find(b => b.Id == magazineId);
        if (magazineFound == null) { throw new Exception("Invalid Id"); }
        return Ok(magazineFound);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof GetByID

    [HttpPost]
    public ActionResult<string> Create([FromBody] Magazine newMagazine)
    {
      try
      {
        FakeDB.magazines.Add(newMagazine);
        return Created($"api/magazines/{newMagazine.Id}", newMagazine);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof create

    [HttpPut("{magazineId}")]
    public ActionResult<Magazine> Edit(string magazineId, [FromBody] Magazine updatedMagazine)
    {
      try
      {
        Magazine magazineToUpdate = FakeDB.magazines.Find(b => b.Id == magazineId);
        if (magazineToUpdate == null) { throw new Exception("Invalid ID"); }
        magazineToUpdate.Title = updatedMagazine.Title;
        magazineToUpdate.Publisher = updatedMagazine.Publisher;
        magazineToUpdate.Volume = updatedMagazine.Volume;
        return Ok(magazineToUpdate);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpPut("{magazineId}/checkout")]
    public ActionResult<Magazine> Checkout(string magazineId)
    {
      try
      {
        Magazine magazineToUpdate = FakeDB.magazines.Find(b => b.Id == magazineId);
        if (magazineToUpdate == null) { throw new Exception("Invalid ID"); }
        magazineToUpdate.Available = false;
        return Ok(magazineToUpdate);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpDelete("{magazineId}")]
    public ActionResult<string> Delete(string magazineId)
    {
      try
      {
        Magazine magazineToRemove = FakeDB.magazines.Find(b => b.Id == magazineId);
        if (magazineToRemove == null) { throw new Exception("Invalid ID"); }
        FakeDB.magazines.Remove(magazineToRemove);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof delete

  }//endof class

}//endof namespace