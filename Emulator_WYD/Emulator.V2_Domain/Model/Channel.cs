using System.Net.Sockets;

namespace Emulator.V2_Domain.Model
{
    public sealed class Channel
    {
        public static readonly Channel Instance = new Channel();
        private Channel() { }

        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string IpAddress { get; set; } = string.Empty;
        public int PortAddress { get; set; }
        public int UserLimit { get; set; }

        public Socket? Socket { get; set; }
    }
}
