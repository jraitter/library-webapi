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
  public class AuthorsController : ControllerBase
  {
    private readonly AuthorService _as;
    private readonly BookService _bs;

    // NOTE Dependency Injection
    public AuthorsController(AuthorService ass, BookService bs)
    {
      _as = ass;
      _bs = bs;
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

    [HttpGet("{authorId}")]
    public ActionResult<Author> GetByID(int authorId)
    {
      try
      {
        return Ok(_as.Get(authorId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof GetByID

    [HttpGet("{authId}/books")]
    public ActionResult<IEnumerable<Book>> GetBooksByAuthId(int authId)
    {
      try
      {
        return Ok(_bs.GetBooksByAuthId(authId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof

    [HttpPost]
    [Authorize]
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

    [HttpPut("{authorId}")]
    [Authorize]
    public ActionResult<Author> Edit(int authorId, [FromBody] Author updatedAuthor)
    {
      try
      {
        updatedAuthor.Id = authorId;
        return Ok(_as.Edit(updatedAuthor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpDelete("{authorId}")]
    [Authorize]
    public ActionResult<string> Delete(int authorId)
    {
      try
      {
        return Ok(_as.Delete(authorId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof delete

  }//endof class

}//endof namespace