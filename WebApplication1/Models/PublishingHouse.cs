namespace Book_Web.Models
{
    public class PublishingHouse
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public string? Email { get; set; }
        public DateTime Last_Login { get; set; }
    }
}
