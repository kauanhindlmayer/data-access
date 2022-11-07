using Dapper.Contrib.Extensions;

namespace Desafio.Models
{
  [Table("[Post]")]
  public class Post
  {
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
  }
}