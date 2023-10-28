using Emulator.V2_Domain.Model.Enum;
using System.Net.Sockets;

namespace Emulator.V2_Domain.Model
{
    public record class Client
    {
        public Client(Server server, Socket socket)
        {
            Server = server;
            Socket = socket;
        }

        public Server Server { get; set; }
        public Socket Socket { get; set; }
        public bool IsActive { get; set; } = true;
        public ClientStatus Status { get; set; } = ClientStatus.Connection;
        public byte[] Buffer { get; set; } = new byte[1024];
    }
}
