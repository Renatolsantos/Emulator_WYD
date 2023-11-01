using System.Text;

namespace Emulator_WYD.Helper
{
    public static class ByteExtension
    {
        public static byte[] ToByteArray<T>(this T obj)
        {
            if (obj is null)
            {
                return Array.Empty<byte>();
            }

            switch (typeof(T).Name)
            {
                case "string":
                {
                    return Encoding.ASCII.GetBytes(obj.ToString()!);
                }
                default: return Array.Empty<byte>();
            }
        }

        public static string BytesToString(this byte[] bytes)
        {
            if (bytes == null || !bytes.Any())
            {
                return string.Empty;
            }

            return Encoding.ASCII.GetString(bytes);
        }
    }
}
