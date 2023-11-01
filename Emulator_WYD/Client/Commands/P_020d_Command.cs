using Emulator_WYD.Client.Commands.Interfaces;
using Emulator_WYD.Model.Structures;

namespace Emulator_WYD.Client.Commands
{
    public class P_020d_Command : ICommand
    {
        public void Execute(Client client, byte[] data)
        {
            if(data == null)
            {
                throw new ArgumentNullException(nameof(data), $"Data cannot be null. ClientId {data}");
            }

            client.Send(P_101_Struct.New("Worked"));
        }
    }
}
