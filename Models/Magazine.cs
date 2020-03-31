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
    public int Id { get; set; }

  }//end of class Magazine
}//end of namespace