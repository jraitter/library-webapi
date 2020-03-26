using System.Collections.Generic;

namespace library_webapi.Models
{

  public static class FakeDB
  {
    public static List<Book> books = new List<Book>()
{
  new Book("Where The Sidewalk Ends","Shel Silverstein"),
  new Book("Star Wars: A New Hope","Ryder Windham"),
  new Book("Star Wars: Empire Strikes Back","Ryder Windham"),
  new Book("Star Wars: Return of the Jedi","Ryder Windham")
};

    public static List<Magazine> magazines = new List<Magazine>()
{
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Original"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.1"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.2"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.3"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.4"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.5"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.6"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.7"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.8"),
    new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.9"),
     new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.10"),
     new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.11"),
     new Magazine("Arizona Highways", false,"AZ. Magazine", "Volume1968.12")
};

  }//endof class
}//enfo namesapce