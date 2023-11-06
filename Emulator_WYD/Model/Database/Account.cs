namespace Emulator_WYD.Model.Database
{
    public record class Account : ModelBase
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
