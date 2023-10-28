using System.Net.Sockets;

namespace Emulator.V2_Domain.Model
{
    public record class Server
    {
        public bool IsActive { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public int PortAddress { get; set; }
        public int UsersLimit { get; set; }
        public int EventTick { get; set; }


        public Socket? Socket { get; set; }
        public IList<Client> Clients { get; set; } = new List<Client>();
    }
}
