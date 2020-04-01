namespace library_webapi.Models
{
  public class BookAuthor
  {
    public int Id { get; set; }
    public int BookId { get; set; }
    public int AuthId { get; set; }
  }

  public class DBBookAuthor : BookAuthor
  {
    public int baId { get; set; }
  }
}