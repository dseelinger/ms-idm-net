using System.DirectoryServices.AccountManagement;

namespace IdmNet.Tests.TestModels
{
    public class TestUserInfo
    {
        public UserPrincipal AdUser { get; set; }
        public string DisplayName { get; set; }
        public string AccountName { get; set; }
        public string Domain { get; set; }
        public string Password { get; set; }
        public string ObjectId { get; set; }
    }
}
