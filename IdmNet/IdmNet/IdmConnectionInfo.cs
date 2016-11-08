namespace IdmNet
{
    /// <summary>
    /// This class holds the information needed to connect to a MIM server.
    /// </summary>
    public class IdmConnectionInfo
    {
        /// <summary>
        /// Fully qualified domain name (or IP address) - could be netbios name if SPNs are set up that way and accessible.
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Name of the user that will connect to MIM (without domain)
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password for the user that will connect to MIM.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Name of the domain (not full domain name) of the user connecting to MIM. For user contos\admin, the domain is "contoso"
        /// </summary>
        public string Domain { get; set; }
    }
}
