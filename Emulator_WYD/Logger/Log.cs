using Emulator_WYD.Model.Structures;

namespace Emulator_WYD.Logger
{
    public static class Log
    {
        // Attributes
        private static readonly string Lock = "";

        /// <summary>
        /// Personalize the console write.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="consoleColor"></param>
        public static void Write(object obj, ConsoleColor consoleColor)
        {
            lock (Lock)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[{DateTimeOffset.UtcNow:dd/MM/yyyy HH:mm:ss}]: ");

                Console.ForegroundColor = consoleColor;
                Console.WriteLine($"{obj}");

                Console.ResetColor();
            }
        }

        public static void Normal(object o) => Write(o, ConsoleColor.White);
        public static void Information(object o) => Write(o, ConsoleColor.Cyan);
        public static void Error(object o) => Write(o, ConsoleColor.Red);

        public static void Receive(Client.Client client, HeaderStruct header)
            => Write(
                $"RCV < P: 0x{header.PacketId.ToString("X").PadLeft(4, '0')} " +
                $"| S: {header.Size.ToString().PadLeft(4, '0')} " +
                $"| CID: {header.ClientId.ToString().PadLeft(5, '0')}", ConsoleColor.Magenta);
        public static void Send(Client.Client c, HeaderStruct h)
            => Write(
                $"SND > P: 0x{h.PacketId.ToString("X").PadLeft(4, '0')} " +
                $"| S: {h.Size.ToString().PadLeft(4, '0')} " +
                $"| CID: {h.ClientId.ToString().PadLeft(5, '0')}", ConsoleColor.Green);
    }
}