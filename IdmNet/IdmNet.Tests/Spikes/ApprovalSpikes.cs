using System;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests.Spikes
{
    [TestClass]
    public class ApprovalSpikes
    {
        [TestMethod]
        public async Task CreateTheUser()
        {
            // Create the user
            var ouContex = new PrincipalContext(ContextType.Domain, "fimdom.lab", "CN=Users,DC=fimdom,DC=lab");
            var up = new UserPrincipal(ouContex) { SamAccountName = "ApprovalTestUser01", Enabled = true };
            up.SetPassword("Password1");
            var sidBytes = new byte[28];
            up?.Sid.GetBinaryForm(sidBytes, 0);

            // Create the user in identity manager
            IdmNetClient idmClient = IdmNetClientFactory.BuildClient();

            var person = new Person
            {
                DisplayName = "Approval Test User 01",
                AccountName = "ApprovalTestUser01",
                Domain = "FIMDOM",
                ObjectSID = sidBytes
            };

            var result = await idmClient.PostAsync(person);
        }
    }
}
