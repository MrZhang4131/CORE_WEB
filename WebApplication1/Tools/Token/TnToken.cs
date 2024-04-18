namespace Book_Web.Tools.Token
{
    public class TnToken
    {
        public string? TokenStr { get; set; }
        public DateTime Expires { get; set; }
        public string? Identity { get; set; }
        public string? name { get; set; }
    }
}
