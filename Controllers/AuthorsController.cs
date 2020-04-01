using System;
using System.Collections.Generic;
using library_webapi.Models;
using library_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_webapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthorsController : ControllerBase
  {
    private readonly AuthorService _as;
    // NOTE Dependency Injection
    public AuthorsController(AuthorService ass)
    {
      _as = ass;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Author>> Get()
    {
      try
      {
        return Ok(_as.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof Get

    [HttpGet("{bookId}")]
    public ActionResult<Author> GetByID(int bookId)
    {
      try
      {
        return Ok(_as.Get(bookId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof GetByID

    [HttpPost]
    public ActionResult<string> Create([FromBody] Author newAuthor)
    {
      try
      {
        return Ok(_as.Create(newAuthor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof create

    [HttpPut("{bookId}")]
    public ActionResult<Author> Edit(int bookId, [FromBody] Author updatedAuthor)
    {
      try
      {
        updatedAuthor.Id = bookId;
        return Ok(updatedAuthor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpDelete("{bookId}")]
    public ActionResult<string> Delete(int bookId)
    {
      try
      {
        return Ok(_as.Delete(bookId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof delete

  }//endof class

}//endof namespace