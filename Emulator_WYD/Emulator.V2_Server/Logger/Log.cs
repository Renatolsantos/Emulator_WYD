namespace Emulator_WYD.Logger
{
    public static class Log
    {
        // Atributos
        private static readonly string Lock = "";

        // Métodos
        public static void Write(object o, ConsoleColor c)
        {
            lock (Lock)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[{DateTimeOffset.UtcNow:dd/MM/yyyy HH:mm:ss}]: ");

                Console.ForegroundColor = c;
                Console.WriteLine($"{o}");

                Console.ResetColor();
            }
        }

        public static void Normal(object o) => Write(o, ConsoleColor.White);
        public static void Information(object o) => Write(o, ConsoleColor.Cyan);
        public static void Error(object o) => Write(o, ConsoleColor.Red);
    }
}