namespace WebApi.Models.Usom
{
    public class Document
    {
        public int totalCount { get; set; }
        public int count { get; set; }
        public List<DocumentItem>? models { get; set; }
      //  public int page { get; set; }
      //  public int pageCount { get; set; }
    }
}
