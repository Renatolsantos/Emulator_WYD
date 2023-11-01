using Emulator_WYD.Client.Commands;
using Emulator_WYD.Helper;
using Emulator_WYD.Logger;
using Emulator_WYD.Model.Enum;
using Emulator_WYD.Model.Structures;
using System.Net;
using System.Net.Sockets;

namespace Emulator_WYD.Client
{
    /// <summary>
    /// Instance of client service
    /// </summary>
    public class Client
    {
        public Server.Server Server { get; private set; }
        public Socket Socket { get; private set; }
        public bool IsActive { get; private set; } = true;
        public ClientStatus Status { get; private set; } = ClientStatus.Connection;
        public byte[] Buffer { get; private set; } = new byte[1024];

        /// <summary>
        /// Constructor for <see cref="Client"/>.
        /// </summary>
        /// <param name="server">The server related to the <see cref="Client"/>.</param>
        /// <param name="socket">The client socket</param>
        public Client(Server.Server server, Socket socket)
        {
            Server = server;
            Socket = socket;

            BeginReceive();
        }

        /// <summary>
        /// Close the socket connection.
        /// </summary>
        public void CloseConnection()
        {
            if (IsActive)
            {
                IsActive = false;
                Status = ClientStatus.Disconnect;
                Socket.Close(1000);

                Server.Clients.Remove(this);
            }
        }

        /// <summary>
        /// Send package to the socket connection.
        /// </summary>
        /// <typeparam name="T">The type of the package to send.</typeparam>
        /// <param name="obj"></param>
        public void Send<T>(T obj)
        {
            if (obj == null)
            {
                Log.Error("Source value cannot be null");
            }
            else
            {
                byte[] send = ByteExtension.ToByteArray(obj);

                Log.Send(this, PackageConvert.ToStruct<HeaderStruct>(send));

                PSecurity.Encrypt(ref send);

                Socket.BeginSend(send, 0, send.Length, SocketFlags.None, null, null);
            }
        }

        /// <summary>
        /// Start to consume packages from the client socket.
        /// </summary>
        private void BeginReceive()
        {
            if (IsActive)
            {
                Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
        }

        /// <summary>
        /// After receive a package from the client socket.
        /// </summary>
        /// <param name="asyncResult">The call back parameter.</param>
        private void OnReceive(IAsyncResult asyncResult)
        {
            try
            {
                var packageSize = Socket.EndReceive(asyncResult);

                var remoteInformation = Socket.RemoteEndPoint as IPEndPoint;

                Log.Information($"Package received from {remoteInformation?.Address}:{remoteInformation?.Port}");

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

                CommandHandler.Handle(this, buffer);
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
    }
}
