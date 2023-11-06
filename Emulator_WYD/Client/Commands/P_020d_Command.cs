using Emulator_WYD.Client.Commands.Interfaces;
using Emulator_WYD.Data.Context;
using Emulator_WYD.Data.Repository;
using Emulator_WYD.Helper;
using Emulator_WYD.Model.Database;
using Emulator_WYD.Model.Structures;
using System.Text.RegularExpressions;

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

            var account = PackageConvert.ToStruct<P_020d_Struct>(Data);

            // TODO: Change to a better way to create account
            // TODO: Add cryptography hash key to protect the password

            if (!Regex.IsMatch(account.UserName, @"^[A-Za-z0-9]{5,12}$"))
            {
                Client.CloseConnection("User name only accepted numbers ad letters. Maximum 5 to 12 characters.");
                return;
            }
            if (!Regex.IsMatch(account.Password, "^[a-zA-Z0-9@!#$]{5,10}$"))
            {
                Client.CloseConnection("Password only accepted numbers, letters and !@#$. Maximum 5 a 10 characters.");
                return;
            }

            lock (string.Empty)
            {
                var accountRepository = new AccountRepository();

                var accountDatabase = accountRepository.GetByUserName(account.UserName);

                if (accountDatabase == null)
                {
                    Client.ClientId = accountRepository.Create(new Account
                    {
                        UserName = account.UserName,
                        Password = account.Password
                    });

                    accountDatabase = accountRepository.GetByUserName(account.UserName);
                }
                else
                {
                    Client.ClientId = accountDatabase.Id;
                }

                if (Client.ClientId == 0)
                {
                    Client.Send(P_101_Struct.New("Login fail."));
                    return;
                }

                if (!accountDatabase!.Password.Equals(account.Password))
                {
                    Client.Send(P_101_Struct.New("Wrong password."));
                    return;
                }

                Client.Send(P_101_Struct.New($"Welcome {account.UserName}."));
                // TODO: Send user to the character selection
            }
        }
    }
}
