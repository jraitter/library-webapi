using System;
using System.ComponentModel.DataAnnotations;

namespace library_webapi.Models
{
  public class Author
  {
    [Required]
    [MinLength(2)]
    public string Name { get; set; }

    [Required]
    [MinLength(2)]
    public string Publication { get; set; }
    public int Id { get; set; }

  }//end of class Book
}//end of namespace