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
  public class BooksController : ControllerBase
  {
    private readonly BookService _bs;
    private readonly AuthorService _as;

    // NOTE Dependency Injection
    public BooksController(BookService bs, AuthorService ass)
    {
      _bs = bs;
      _as = ass;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof Get

    [HttpGet("{bookId}")]
    public ActionResult<Book> GetByID(int bookId)
    {
      try
      {
        return Ok(_bs.Get(bookId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof GetByID

    [HttpGet("{bookId}/authors")]
    public ActionResult<IEnumerable<Author>> GetAuthorsByBookId(int bookId)
    {
      try
      {
        return Ok(_as.GetAuthorsByBookId(bookId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof

    [HttpPost]
    [Authorize]

    public ActionResult<string> Create([FromBody] Book newBook)
    {
      try
      {
        return Ok(_bs.Create(newBook));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof create

    [HttpPut("{bookId}")]
    [Authorize]
    public ActionResult<Book> Edit(int bookId, [FromBody] Book updatedBook)
    {
      try
      {
        updatedBook.Id = bookId;
        return Ok(_bs.Edit(updatedBook));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpPut("{bookId}/checkout")]
    [Authorize]

    public ActionResult<Book> CheckOut(int bookId)
    {
      try
      {
        Book bookToCheckout = _bs.Get(bookId);
        if (bookToCheckout == null) { throw new Exception("Invalid ID"); }
        bookToCheckout.Available = false;
        return Ok(_bs.CheckOut(bookToCheckout));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof checkout

    [HttpPut("{bookId}/checkin")]
    [Authorize]

    public ActionResult<Book> CheckIn(int bookId)
    {
      try
      {
        Book bookToCheckin = _bs.Get(bookId);
        if (bookToCheckin == null) { throw new Exception("Invalid ID"); }
        bookToCheckin.Available = true;
        return Ok(_bs.CheckOut(bookToCheckin));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof checkin

    [HttpDelete("{bookId}")]
    [Authorize]

    public ActionResult<string> Delete(int bookId)
    {
      try
      {
        return Ok(_bs.Delete(bookId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof delete

  }//endof class

}//endof namespace