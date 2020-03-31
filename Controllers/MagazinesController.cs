using System;
using System.Collections.Generic;
using library_webapi.Models;
using library_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_webapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MagazinesController : ControllerBase
  {
    private readonly MagazineService _ms;
    // NOTE Dependency Injection
    public MagazinesController(MagazineService ms)
    {
      _ms = ms;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Magazine>> Get()
    {
      try
      {
        return Ok(_ms.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof Get

    [HttpGet("{magazineId}")]
    public ActionResult<Magazine> GetByID(int magazineId)
    {
      try
      {
        return Ok(_ms.Get(magazineId));
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
        return Ok(_ms.Create(newMagazine));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof create

    [HttpPut("{magazineId}")]
    public ActionResult<Magazine> Edit(int magazineId, [FromBody] Magazine updatedMagazine)
    {
      try
      {
        updatedMagazine.Id = magazineId;
        return Ok(updatedMagazine);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof edit

    [HttpPut("{magazineId}/checkout")]
    public ActionResult<Magazine> Checkout(int magazineId)
    {
      try
      {
        Magazine magazineToCheckout = _ms.Get(magazineId);
        if (magazineToCheckout == null) { throw new Exception("Invalid ID"); }
        magazineToCheckout.Available = false;
        return Ok(_ms.CheckOut(magazineToCheckout));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof checkout

    [HttpDelete("{magazineId}")]
    public ActionResult<string> Delete(int magazineId)
    {
      try
      {
        return Ok(_ms.Delete(magazineId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }//endof delete

  }//endof class

}//endof namespace