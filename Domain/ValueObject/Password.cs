
using System.Security.Cryptography;
using System.Text;


namespace Domain.ValueObject
{
    public class Password
    {
        private const int MaxLenght = 255;
        private const int MinLenght = 8;







        private Password(string value) => Value = value;


        public static Password? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < MinLenght || value.Length > MaxLenght)
            {
                return null;
            }
            SHA256? sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[]? stream = sha256.ComputeHash(encoding.GetBytes(value));
            StringBuilder? sb = new StringBuilder();

            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);

         

            return new Password(sb.ToString());
        }

        public string Value { get; init; }

    }
}
