namespace Emulator_WYD.Client.Commands.Interfaces
{
    public interface ICommand
    {
        void Execute(Client client, byte[] data);
    }
}
