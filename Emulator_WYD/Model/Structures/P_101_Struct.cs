using Emulator_WYD.Helper;
using System.Runtime.InteropServices;

namespace Emulator_WYD.Model.Structures
{
    /// <summary>
	/// Alert package struct (size 108)
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct P_101_Struct
    {
        // Attributes
        public HeaderStruct Header; // 0 a 11		= 12

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public byte[] MessageBytes; // 12 a 91	= 80

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Unknow1;      // 92 a 107	= 16

        // Helpers
        public string Message
        {
            get => MessageBytes.BytesToString();
            set
            {
                MessageBytes = value.ToByteArray();
                Array.Resize(ref MessageBytes, 80);
            }
        }

        // Constructors
        public static P_101_Struct New(string Message)
        {
            P_101_Struct tmp = new P_101_Struct
            {
                Header = HeaderStruct.New(0x0101, Marshal.SizeOf<P_101_Struct>(), 0),
                Message = Message,
                Unknow1 = new byte[16]
            };

            return tmp;
        }
    }
}
