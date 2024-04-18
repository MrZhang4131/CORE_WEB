namespace Book_Web.Tools.Token
{
    public class TokenOption_Format
    {
        public string? Issuer { get; set; }

        public string? Audience { get; set; }

        public string? IssuerSigningKey { get; set; }

        public int AccessTokenExpiresMinutes { get; set; }
    }
}
