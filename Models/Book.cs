using System;
using System.ComponentModel.DataAnnotations;

namespace library_webapi.Models
{
  public class Book
  {
    [Required]
    [MinLength(2)]
    public string Title { get; set; }

    [Required]
    [MinLength(2)]
    public string Author { get; set; }
    public bool Available { get; set; }
    public string Id { get; set; }

    //constructors
    //parameterless ctor required for Post
    public Book()
    {
      string UUID = Guid.NewGuid().ToString();
      Available = true;
      Id = UUID;
    }

    //ctor w/ params needed for FakeDB
    public Book(string title, string author)
    {
      string UUID = Guid.NewGuid().ToString();
      Title = title;
      Author = author;
      Available = true;
      Id = UUID;
    }
  }//end of class Book
}//end of namespace