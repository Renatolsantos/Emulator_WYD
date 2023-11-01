using System.Runtime.InteropServices;
using System.Text;

namespace Emulator_WYD.Helper
{
    public static class ByteExtension
    {
        public static byte[] ToByteArray<T>(T obj)
        {
            if (obj == null)
            {
                return Array.Empty<byte>();
            }

            int size = Marshal.SizeOf(obj);
            byte[] byteArray = new byte[size];

            var handle = GCHandle.Alloc(byteArray, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Marshal.StructureToPtr(obj, pointer, false);
                return byteArray;
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
        }

        public static byte[] ToByteArray(this string value)
            => Encoding.UTF8.GetBytes(value);

        public static string BytesToString(this byte[] bytes)
        {
            if (bytes == null || !bytes.Any())
            {
                return string.Empty;
            }

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
