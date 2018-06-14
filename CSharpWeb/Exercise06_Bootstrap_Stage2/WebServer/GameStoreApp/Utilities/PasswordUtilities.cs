namespace HTTPServer.GameStoreApp.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public static class PasswordUtilities
    {
        public static string GetHash(string password)
        {
            string hash = "";

            using (SHA256 sha256hash = SHA256.Create())
            {
                hash = GetSha256Hash(sha256hash, password);
            }

            return hash;
        }

        private static string GetSha256Hash(SHA256 shaHash, string input)
        {
            byte[] data = shaHash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}