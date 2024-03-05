namespace Api.Common.Paginator
{
  public class PaginationResult<T>
  {
    public List<T> Data { get; set; }
    public int TotalItems { get; set; }
  }
}