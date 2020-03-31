using System;
using System.Collections.Generic;
using library_webapi.Models;
using library_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_webapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly BookService _bs;
    // NOTE Dependency Injection
    public BooksController(BookService bs)
    {
      _bs = bs;
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

    [HttpPost]
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
    public ActionResult<Book> Edit(int bookId, [FromBody] Book updatedBook)
    {
      try
      {
        updatedBook.Id = bookId;
        return Ok(updatedBook);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpPut("{bookId}/checkout")]
    public ActionResult<Book> Checkout(int bookId)
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

    [HttpDelete("{bookId}")]
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