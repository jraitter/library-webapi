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
    public int Id { get; set; }

  }//end of class Book
}//end of namespace