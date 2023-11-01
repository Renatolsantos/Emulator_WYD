using Emulator_WYD.Helper;
using Emulator_WYD.Logger;
using Emulator_WYD.Model;
using Emulator_WYD.Model.Enum;
using System.Net.Sockets;

namespace Emulator_WYD.Client
{
    public class Client
    {
        public Client(Server server, Socket socket)
        {
            Server = server;
            Socket = socket;

            BeginReceive();
        }

        public Server Server { get; private set; }
        public Socket Socket { get; private set; }
        public bool IsActive { get; private set; } = true;
        public ClientStatus Status { get; private set; } = ClientStatus.Connection;
        public byte[] Buffer { get; private set; } = new byte[1024];

        private void BeginReceive()
        {
            if (IsActive)
            {
                Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
        }

        private void OnReceive(IAsyncResult asyncResult)
        {
            try
            {
                var packageSize = Socket.EndReceive(asyncResult);

                if (packageSize <= 0)
                {
                    CloseConnection();
                    return;
                }

                var buffer = Buffer.Take(packageSize).ToArray();

                if (Status == ClientStatus.Connection)
                {
                    if (packageSize == 4)
                    {
                        return;
                    }
                    if (packageSize == 120)
                    {
                        buffer = buffer.Skip(4).ToArray();
                    }

                    Status = ClientStatus.Login;
                }

                if (packageSize < 12)
                {
                    CloseConnection();
                    return;
                }

                PSecurity.Decrypt(buffer);
                Log.Information($"Package received: {buffer.BytesToString()}");


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

        public void Send<T>(T obj)
        {
            if (obj == null)
            {
                Log.Error("Source value cannot be null");
            }
            else
            {
                byte[] send = obj.ToByteArray();

                //Log.Snd(this, PConvert.ToStruct<SHeader>(send));

                PSecurity.Encrypt(ref send);

                Socket.BeginSend(send, 0, send.Length, SocketFlags.None, null, null);
            }
        }

        private void CloseConnection()
        {
            if (IsActive)
            {
                IsActive = false;
                Status = ClientStatus.Disconnect;
                Socket.Close(1000);

                Server.Clients.Remove(this);
            }
        }
    }
}
