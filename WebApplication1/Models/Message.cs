namespace Book_Web.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Accept { get; set; }
        public string Info { get; set; }
        public DateTime LogTime { get; set; }
    }
}
