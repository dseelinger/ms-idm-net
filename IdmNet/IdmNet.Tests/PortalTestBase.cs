using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using IdmNet.Models;
using IdmNet.SoapModels;
using IdmNet.Tests.TestModels;

namespace IdmNet.Tests
{
    public class PortalTestBase
    {
        protected async Task<TestUserInfo> CreateTestUser(string disambiguator)
        {
            // Create the user in AD
            var shortDomain = ConfigurationManager.AppSettings["short_domain"];
            var fullDomain = ConfigurationManager.AppSettings["full_domain"];
            var fullDomainLdap = ConfigurationManager.AppSettings["full_domain_ldap"];

            var ouContex = new PrincipalContext(ContextType.Domain, fullDomain, fullDomainLdap);
            string accountName = $"_TU_{disambiguator}";
            var up = new UserPrincipal(ouContex) { SamAccountName = accountName, Enabled = true, DisplayName = accountName};
            up.SetPassword("Password1");
            up.Save(ouContex);

            var user = UserPrincipal.FindByIdentity(ouContex, accountName);
            var sidBytes = new byte[28];
            user?.Sid.GetBinaryForm(sidBytes, 0);

            // Create the user in identity manager
            IdmNetClient idmClient = IdmNetClientFactory.BuildClient();

            var person = new Person
            {
                DisplayName = $"Approval Test User {disambiguator}",
                AccountName = accountName,
                Domain = shortDomain,
                ObjectSID = sidBytes
            };

            var result = await idmClient.CreateAsync(person);
            var objectId = idmClient.GetNewObjectId(result);

            return new TestUserInfo
            {
                AdUser = up,
                DisplayName = person.DisplayName,
                AccountName = person.AccountName,
                Domain = shortDomain,
                Password = "Password1",
                ObjectId = objectId
            };
        }

        protected async Task DeleteUser(TestUserInfo testUser)
        {
            try
            {
                // Delete the user from Identity Manager
                IdmNetClient idmClient = IdmNetClientFactory.BuildClient();
                await idmClient.DeleteAsync(testUser.ObjectId);
            }
            finally
            {
                // Delete the user from AD
                testUser.AdUser.Delete();
            } 
        }

        protected async Task<string> CreateGroup(TestUserInfo ownerUser, string disambiguator)
        {
            // Create the user in identity manager
            var shortDomain = ConfigurationManager.AppSettings["short_domain"];
            string fqdn = IdmNetClientFactory.GetEnvironmentSetting("MIM_fqdn");
            var adminClient = IdmNetClientFactory.BuildClient();
            var ownerClient =
                IdmNetClientFactory.BuildClient(new IdmConnectionInfo
                {
                    Domain = ownerUser.Domain,
                    Server = fqdn,
                    Username = ownerUser.AccountName,
                    Password = ownerUser.Password
                });

            // Look up the items needed to construct the group...
            // ...Owner
            var ownerObj =
                await ownerClient.GetAsync(ownerUser.ObjectId, new List<string> { "DisplayName" });
            var owner = new Person(ownerObj);

            // ...Domain Config
            var domainConfigSearch =
                await
                    adminClient.SearchAsync(new SearchCriteria("/DomainConfiguration[DisplayName='" + shortDomain + "']"));
            var domainConfig = new DomainConfiguration(domainConfigSearch.First());

            var fimObj = new Group
            {
                DisplayName = $"Approval Test Group {disambiguator}",
                DisplayedOwner = owner,
                Domain = shortDomain,
                DomainConfiguration = domainConfig,
                MailNickname = "ApprovalTestGroup{disambiguator}",
                ExplicitMember = new List<IdmResource> { owner },
                MembershipAddWorkflow = "Owner Approval",
                MembershipLocked = false,
                Owner = new List<Person> { owner },
                Scope = "Universal",
                Type = "Distribution"
            };

            var result = await ownerClient.CreateAsync(fimObj);
            var objectId = ownerClient.GetNewObjectId(result);
            return objectId;
        }

        protected async Task DeleteGroup(string objectId)
        {
            // Delete the user from Identity Manager
            IdmNetClient idmClient = IdmNetClientFactory.BuildClient();
            await idmClient.DeleteAsync(objectId);
        }
    }

}
