using System.Text;

namespace ContractManagment.Client.State
{
    public static class StringBinaryConverter
    {
        public static byte[] ToByteArray(this string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string ToHexString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static string InString(this byte[] bytes)
        {
            string str = "";
            foreach (byte b in bytes)
            {
                str += b;
                str += " ";
            }
            return str;
        }
    }
}
