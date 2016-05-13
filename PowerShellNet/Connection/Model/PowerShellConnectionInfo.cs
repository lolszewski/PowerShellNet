namespace PowerShellNet.Connection.Model
{
    public class PowerShellConnectionInfo
    {
        public virtual string MachineNameOrAddress { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string Port { get; set; }

        public virtual string ShellUrl { get; set; } = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";

        public virtual string ApplicationName { get; set; } = "/wsman";
    }
}
