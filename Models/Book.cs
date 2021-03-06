using System;
using System.ComponentModel.DataAnnotations;

namespace library_webapi.Models
{
  public class Book
  {
    public int Id { get; set; }

    [Required]
    [MinLength(2)]
    public string Title { get; set; }

    [Required]
    [MinLength(2)]
    public string Author { get; set; }
    public int LibId { get; set; }
    public bool Available { get; set; }

  }//end of class Book
}//end of namespace