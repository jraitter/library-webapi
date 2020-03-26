using System;
using System.Collections.Generic;
using library_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_webapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
      try
      {
        return Ok(FakeDB.books);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof Get

    [HttpGet("{bookId}")]
    public ActionResult<Book> GetByID(string bookId)
    {
      try
      {
        Book bookFound = FakeDB.books.Find(b => b.Id == bookId);
        if (bookFound == null) { throw new Exception("Invalid Id"); }
        return Ok(bookFound);
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
        FakeDB.books.Add(newBook);
        return Created($"api/books/{newBook.Id}", newBook);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof create

    [HttpPut("{bookId}")]
    public ActionResult<Book> Edit(string bookId, [FromBody] Book updatedBook)
    {
      try
      {
        Book bookToUpdate = FakeDB.books.Find(b => b.Id == bookId);
        if (bookToUpdate == null) { throw new Exception("Invalid ID"); }
        bookToUpdate.Title = updatedBook.Title;
        bookToUpdate.Author = updatedBook.Author;
        return Ok(bookToUpdate);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpPut("{bookId}/checkout")]
    public ActionResult<Book> Checkout(string bookId)
    {
      try
      {
        Book bookToUpdate = FakeDB.books.Find(b => b.Id == bookId);
        if (bookToUpdate == null) { throw new Exception("Invalid ID"); }
        bookToUpdate.Available = false;
        return Ok(bookToUpdate);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpDelete("{bookId}")]
    public ActionResult<string> Delete(string bookId)
    {
      try
      {
        Book bookToRemove = FakeDB.books.Find(b => b.Id == bookId);
        if (bookToRemove == null) { throw new Exception("Invalid ID"); }
        FakeDB.books.Remove(bookToRemove);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof delete

  }//endof class

}//endof namespace