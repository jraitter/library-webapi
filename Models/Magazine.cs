using System;
using System.ComponentModel.DataAnnotations;

namespace library_webapi.Models
{
  public class Magazine
  {
    [Required]
    [MinLength(2)]
    public string Title { get; set; }

    [Required]
    [MinLength(2)]
    public string Publisher { get; set; }
    public string Volume { get; set; }
    public bool Available { get; set; }
    public string Id { get; set; }

    //constructors
    //parameterless ctor required for Post
    public Magazine()
    {
      string UUID = Guid.NewGuid().ToString();
      Available = true;
      Id = UUID;
    }

    //ctor w/ params needed for FakeDB
    public Magazine(string title, bool checkedOut, string publisher, string volume)
    {
      Title = title;
      Available = true;
      Publisher = publisher;
      Volume = volume;
      string UUID = Guid.NewGuid().ToString();
      Id = UUID;
    }
  }//end of class Magazine
}//end of namespace