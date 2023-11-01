using Emulator_WYD.Helper;
using Emulator_WYD.Logger;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Sockets;

namespace Emulator_WYD.Model
{
    public sealed class Server
    {
        private Server() { }
        private static Server? _instance;

        public static Server GetInstace()
        {
            if (_instance == null)
            {
                _instance = new Server();
            }

            return _instance;
        }

        private bool IsActive;
        public string Name { get; private set; } = string.Empty;
        public string IpAddress { get; private set; } = string.Empty;
        public int PortAddress { get; private set; }
        public int UsersLimit { get; private set; }
        public int EventTick { get; private set; }


        public Socket? Socket { get; private set; }
        public IList<Client.Client> Clients { get; private set; } = new List<Client.Client>();

        public void Start(IConfiguration configuration)
        {
            if (IsActive)
            {
                return;
            }

            try
            {
                Log.Information("Configuring server...");

                Configure(configuration);

                Log.Information("Server configured.");

                Log.Information($"Starting the {Name} server...");

                if (!IPAddress.TryParse(IpAddress, out var ipAddress))
                {
                    throw new InvalidCastException("Incorrect Ip Address configured.");
                }

                var iPEndPoint = new IPEndPoint(ipAddress, PortAddress);

                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket.Bind(iPEndPoint);
                Socket.Listen(0);
                IsActive = true;

                BeginAccept();

                Log.Information($"Server {Name} running at {iPEndPoint.Address}:{iPEndPoint.Port}");

                Task.WaitAll(RunAsync());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void Configure(IConfiguration configuration)
        {
            var serverSection = configuration.GetSection("Server");

            Name = serverSection.GetValue<string>(nameof(Name)) ?? string.Empty;
            IpAddress = serverSection.GetValue<string>(nameof(IpAddress)) ?? string.Empty;
            PortAddress = serverSection.GetValue<int>(nameof(PortAddress));
            UsersLimit = serverSection.GetValue<int>(nameof(UsersLimit));
            EventTick = serverSection.GetValue<int>(nameof(EventTick));
        }

        private void BeginAccept()
        {
            try
            {
                Socket!.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void OnAccept(IAsyncResult asyncResult)
        {
            try
            {
                var clientSocker = Socket!.EndAccept(asyncResult);

                if (Clients.Count == UsersLimit)
                {
                    // TODO: change to correct package format
                    clientSocker.Send("Connection limit exceeded".ToByteArray());
                    clientSocker.Disconnect(false);
                    clientSocker.Close();
                }
                else
                {
                    Clients.Add(new Client.Client(this, clientSocker));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                BeginAccept();
            }
        }

        private async Task RunAsync()
        {
            while (IsActive)
            {
                try
                {

                    //Log.Normal("Tick");
                    await Task.Delay(EventTick);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }
    }
}
