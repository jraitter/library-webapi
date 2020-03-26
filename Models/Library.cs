namespace library_webapi.Models
{
  public class library
  {
    public string Name { get; set; }
    public string Location { get; set; }
    public library(string name, string location)
    {
      Name = name;
      Location = location;
    }

  }//endof class
}//endof namespace