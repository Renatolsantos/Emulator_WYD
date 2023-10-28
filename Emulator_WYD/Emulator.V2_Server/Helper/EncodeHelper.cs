using System.Text;

namespace Emulator.V2_Host.Helper
{
    public static class EncodeHelper
    {
        public static byte[] ToByteArray(this string str) => Encoding.ASCII.GetBytes(str);

    }
}
