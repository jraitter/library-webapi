using System.ComponentModel.DataAnnotations;

namespace library_webapi.Models
{
  public class Library
  {
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    [MinLength(3)]
    public string Location { get; set; }
    public int Id { get; set; }

  }//endof class
}//endof namespace