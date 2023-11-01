using Emulator_WYD.Client.Commands.Interfaces;
using Emulator_WYD.Helper;
using Emulator_WYD.Logger;
using Emulator_WYD.Model.Structures;

namespace Emulator_WYD.Client.Commands
{
    public static class CommandHandler
    {
        private static readonly string NameSpace = "Emulator_WYD.Model.Structs";

        public static void Handle(Client client, byte[] data)
        {
            var header = PackageConvert.ToStruct<HeaderStruct>(data);
            Log.Receive(client, header);

            if (header.PacketId == 0x03A0)
            {
                if (header.Size != 12 || data.Length != 12)
                {
                    client.CloseConnection();
                }

                return;
            }

            var hexString = header.PacketId.ToString("x4");
            var className = $"P_{hexString}_Command";

            var objType = Type.GetType($"{typeof(CommandHandler).Namespace}.{className}");

            if (objType == null)
            {
                client.Send(P_101_Struct.New($"UNK:0x{hexString}"));
                return;
            }

            var args = new object[] { client, data };
            var instance = Activator.CreateInstance(objType, args);

            if (instance == null)
            {
                throw new Exception($"Was not possible to get instance of {nameof(objType)}");
            }

            (instance as ICommand)!.Execute();
        }
    }
}
