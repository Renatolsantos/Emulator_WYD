using System.Runtime.InteropServices;

namespace Emulator_WYD.Model.Structures
{
    /// <summary>
    /// Package header to 12 size
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HeaderStruct
    {
        // Attributes
        public short Size;      // 0 a 1	= 2
        public byte Key;        // 2		= 1
        public byte CheckSum;   // 3		= 1
        public short PacketId;  // 4 a 5	= 2
        public short ClientId;  // 6 a 7	= 2
        public int TimeStamp;   // 8 a 11	= 4

        /// <summary>
        /// Create a new instance of <see cref="HeaderStruct"/>.
        /// </summary>
        /// <param name="PacketID">The package id.</param>
        /// <param name="Size">The size of the package.</param>
        /// <param name="ClientID">The client id.</param>
        /// <returns>A new <see cref="HeaderStruct"/>.</returns>
        public static HeaderStruct New(short PacketID, int Size, int ClientID)
        {
            HeaderStruct header = new HeaderStruct
            {
                Size = (short)Size,
                Key = 0,
                CheckSum = 0,
                PacketId = PacketID,
                ClientId = (short)ClientID,
                TimeStamp = Environment.TickCount
            };

            return header;
        }
    }
}
