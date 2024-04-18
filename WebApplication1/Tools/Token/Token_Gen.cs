using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Book_Web.Tools.Token
{
    public class Token_Gen : TokenFe
    {
        private readonly TokenOption_Format token;
        public Token_Gen(TokenOption_Format token)
        {
            this.token = token;
        }

        public TnToken CreateToken(string user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, user));
            return GenerateToken(claims,user);
        }
        private TnToken GenerateToken(List<Claim> claims,string user)
        {
            DateTime expires = DateTime.Now.AddMinutes(token.AccessTokenExpiresMinutes);
            var Rtoken = new JwtSecurityToken(
           issuer: token.Issuer,
           audience: token.Audience,
           claims: claims,           //携带的荷载
           notBefore: DateTime.Now,  //token生成时间
           expires: expires,         //token过期时间
           signingCredentials: new SigningCredentials(
               new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.IssuerSigningKey)), SecurityAlgorithms.HmacSha256
               )
           );
            return new TnToken
            {
                Expires = expires,
                TokenStr = new JwtSecurityTokenHandler().WriteToken(Rtoken),
                Identity = user,
            };

        }
    }
}
