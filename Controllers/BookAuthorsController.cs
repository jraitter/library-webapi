using System;
using library_webapi.Models;
using library_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_webapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BookAuthorsController : ControllerBase
  {
    private readonly BookAuthorService _bas;

    public BookAuthorsController(BookAuthorService bas)
    {
      _bas = bas;
    }

    //create
    [HttpPost]
    public ActionResult<BookAuthor> Create([FromBody] BookAuthor newBookAuthor)
    {
      try
      {
        return Ok(_bas.Create(newBookAuthor));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    //delete
    public ActionResult<BookAuthor> Delete([FromBody] BookAuthor toRemove)
    {
      try
      {
        return Ok(_bas.Delete(toRemove));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }//endof class
}//endof namesapce