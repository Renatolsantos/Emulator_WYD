using Emulator_WYD.Helper;
using System.Runtime.InteropServices;

namespace Emulator_WYD.Model.Structures
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct P_020d_Struct
    {
        public HeaderStruct Header;     // 0 a 11	= 12

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] PasswordBytes;    // 12 a 21	= 10

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Unknown1;         // 22 a 23	= 2

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] UserNameBytes;    // 24 a 35	= 12

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
        public byte[] Unknown2;         // 36 a 91	= 56

        public int Version;             // 92 a 95	= 4

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] Unknown3;         // 96 a 115	= 20

        public string UserName { get => UserNameBytes.BytesToString(); }
        public string Password { get => PasswordBytes.BytesToString(); }
    }
}
