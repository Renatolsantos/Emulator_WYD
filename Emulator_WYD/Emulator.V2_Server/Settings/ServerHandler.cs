using Emulator.V2_Client;
using Emulator.V2_CrossCutting;
using Emulator.V2_Domain.Model;
using Emulator.V2_Host.Helper;
using System.Net;
using System.Net.Sockets;

namespace Emulator.V2_Host.Settings
{
    public class ServerHandler
    {
        public Server Server { get; private set; }

        public ServerHandler(Server server)
        {
            Server = server;

            Start();
        }

        private void Start()
        {
            try
            {
                Log.Information($"Starting the {Server.Name} server...");

                if (!IPAddress.TryParse(Server.IpAddress, out var ipAddress))
                {
                    throw new InvalidCastException("Incorrect Ip Address configured.");
                }

                var iPEndPoint = new IPEndPoint(ipAddress, Server.PortAddress);

                Server.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Server.Socket.Bind(iPEndPoint);
                Server.Socket.Listen(0);
                Server.IsActive = true;

                BeginAccept();

                Log.Information($"Server {Server.Name} running at {iPEndPoint.Address}:{iPEndPoint.Port}");

                Task.WaitAll(RunAsync());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void BeginAccept()
        {
            try
            {
                Server.Socket!.BeginAccept(new AsyncCallback(OnAccept), null);
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
                var clientSocker = Server.Socket!.EndAccept(asyncResult);

                if (Server.Clients.Count == Server.UsersLimit)
                {
                    // TODO: change to correct package format
                    clientSocker.Send("Connection limit exceeded".ToByteArray());
                    clientSocker.Disconnect(false);
                    clientSocker.Close();
                }
                else
                {
                    var cliente = new Client(Server, clientSocker);
                    Server.Clients.Add(cliente);

                    new ClientHandler(cliente);
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
            while (Server.IsActive)
            {
                try
                {


                    await Task.Delay(Server.EventTick);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }
    }
}
