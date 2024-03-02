namespace Api.Common.NotFoundException
{
  public class NotFoundException : Exception
  {
    public NotFoundException(string message) : base(message)
    {
    }
  }
}