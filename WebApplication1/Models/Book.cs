namespace Book_Web.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Targe { get; set; }
        public int Population {  get; set; }
        public string? Buy_Url { get; set; }
        public string? ISBN { get; set; }
    }
}
