using System;
using System.Collections.Generic;
using library_webapi.Models;
using library_webapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace library_webapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LibrariesController : ControllerBase
  {
    private readonly LibraryService _ls;
    // NOTE Dependency Injection
    public LibrariesController(LibraryService ls)
    {
      _ls = ls;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Library>> Get()
    {
      try
      {
        return Ok(_ls.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof Get

    [HttpGet("{bookId}")]
    public ActionResult<Library> GetByID(int bookId)
    {
      try
      {
        return Ok(_ls.Get(bookId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof GetByID

    [HttpPost]
    [Authorize]

    public ActionResult<string> Create([FromBody] Library newLibrary)
    {
      try
      {
        return Ok(_ls.Create(newLibrary));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof create

    [HttpPut("{bookId}")]
    [Authorize]

    public ActionResult<Library> Edit(int bookId, [FromBody] Library updatedLibrary)
    {
      try
      {
        updatedLibrary.Id = bookId;
        return Ok(_ls.Edit(updatedLibrary));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpDelete("{bookId}")]
    [Authorize]

    public ActionResult<string> Delete(int bookId)
    {
      try
      {
        return Ok(_ls.Delete(bookId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof delete

  }//endof class

}//endof namespace