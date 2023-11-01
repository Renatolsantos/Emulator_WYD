using Emulator.V2_Client.Helper;
using Emulator.V2_CrossCutting;
using Emulator.V2_Domain.Model;
using Emulator.V2_Domain.Model.Enum;
using System.Net.Sockets;

namespace Emulator.V2_Client
{
    public class ClientHandler
    {
        public Client Client { get; private set; }

        public ClientHandler(Client client)
        {
            Client = client;

            BeginReceive();
        }


        private void BeginReceive()
        {
            if (Client.IsActive)
            {
                Client.Socket.BeginReceive(Client.Buffer, 0, Client.Buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
        }

        private void OnReceive(IAsyncResult asyncResult)
        {
            try
            {
                var packageSize = Client.Socket.EndReceive(asyncResult);

                if (packageSize <= 0)
                {
                    CloseConnection();
                    return;
                }

                var buffer = Client.Buffer.Take(packageSize).ToArray();

                if (Client.Status == ClientStatus.Connection)
                {
                    if (packageSize == 4)
                    {
                        return;
                    }
                    if (packageSize == 120)
                    {
                        buffer = buffer.Skip(4).ToArray();
                    }

                    Client.Status = ClientStatus.Login;
                }

                if (packageSize < 12)
                {
                    CloseConnection();
                    return; 
                }

                PSecurity.Decrypt(buffer);
                Log.Information($"Package received: {buffer}");


            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            finally
            {
                BeginReceive();
            }
        }

        private void CloseConnection()
        {
            if (Client.IsActive)
            {
                Client.IsActive = false;
                Client.Status = ClientStatus.Disconnect;
                Client.Socket.Close();

                Client.Server.Clients.Remove(Client);
            }
        }
    }
}
