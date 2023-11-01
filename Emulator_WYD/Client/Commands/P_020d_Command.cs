using Emulator_WYD.Client.Commands.Interfaces;
using Emulator_WYD.Model.Structures;

namespace Emulator_WYD.Client.Commands
{
    public class P_020d_Command : ICommand
    {
        public P_020d_Command(Client client, byte[] data)
        {
            Client = client;
            Data = data;
        }

        public Client Client { get; }
        public byte[] Data { get; }

        public void Execute()
        {
            if (Data == null)
            {
                throw new ArgumentNullException(nameof(Data), $"Data cannot be null. ClientId {Data}");
            }

            Client.Send(P_101_Struct.New("Worked"));
        }
    }
}
