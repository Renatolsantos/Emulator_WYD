namespace Emulator_WYD.Client.Commands.Interfaces
{
    /// <summary>
    /// An interface to handler command
    /// </summary>
    /// <remarks>
    /// Is behavioral design pattern that converts requests or simple operations into objects.
    /// </remarks>
    public interface ICommand
    {
        void Execute();
    }
}
