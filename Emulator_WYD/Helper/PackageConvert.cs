using Emulator_WYD.Logger;
using System.Runtime.InteropServices;

namespace Emulator_WYD.Helper
{
    public static class PackageConvert
    {
        public static T? ToStruct<T>(byte[] data) => ToStruct<T>(data, 0);

        public static T? ToStruct<T>(byte[] data, int start)
        {
            if (start < 0 || start >= data.Length)
            {
                Log.Error("Start index is out of range");
                return default(T);
            }

            int size = Marshal.SizeOf(typeof(T));
            if (data.Length - start < size)
            {
                Log.Error("Data array is too small to contain the struct");
                return default(T);
            }

            T result;
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                IntPtr ptr = handle.AddrOfPinnedObject() + start;
                result = (T)Marshal.PtrToStructure(ptr, typeof(T))!;
            }
            finally
            {
                handle.Free();
            }

            return result;
        }
    }
}
