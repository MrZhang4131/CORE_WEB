using System.Security.Cryptography;
using System.Text;

namespace Book_Web.Tools.HashGen
{
    public class Hash_Gen : Hash_Interface
    {
        public string GenHash(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);


            using (SHA256 sha256 = SHA256.Create())
            {
                // 计算哈希值
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // 将字节数组转换为十六进制字符串
                input = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                // 输出哈希值

                return input;
            }
        }
    }
}
