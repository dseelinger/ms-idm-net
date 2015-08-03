using System;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using IdmNet.SoapModels;
// ReSharper disable PossibleNullReferenceException

namespace IdmNet
{
    /// <summary>
    /// This class is used to help construct an IdmNet Client object
    /// </summary>
    public class IdmNetClientFactory
    {
        /// <summary>
        /// Build and initialize an IdmNet Client object ready for use
        /// </summary>
        /// <returns>Newly initialized IdmNet Client</returns>
        public static IdmNetClient BuildClient()
        {
            var soapBinding = new IdmSoapBinding();
            string fqdn = GetEnvironmentSetting("MIM_fqdn");
            var endpointIdentity = EndpointIdentity.CreateSpnIdentity("FIMSERVICE/" + fqdn);


            var enumerationPath = "http://" + fqdn + SoapConstants.EnumeratePortAndPath;
            var factoryPath = "http://" + fqdn + SoapConstants.FactoryPortAndPath;
            var resourcePath = "http://" + fqdn + SoapConstants.ResourcePortAndPath;


            var enumerationEndpoint = new EndpointAddress(new Uri(enumerationPath), endpointIdentity);
            var factoryEndpoint = new EndpointAddress(new Uri(factoryPath), endpointIdentity);
            var resourceEndpoint = new EndpointAddress(new Uri(resourcePath), endpointIdentity);


            var searchClient = new SearchClient(soapBinding, enumerationEndpoint);
            var factoryClient = new ResourceFactoryClient(soapBinding, factoryEndpoint);
            var resourceClient = new ResourceClient(soapBinding, resourceEndpoint);



            var credentials = new NetworkCredential(
                GetEnvironmentSetting("MIM_username"),
                GetEnvironmentSetting("MIM_pwd"),
                GetEnvironmentSetting("MIM_domain"));

            searchClient.ClientCredentials.Windows.ClientCredential = credentials;
            factoryClient.ClientCredentials.Windows.ClientCredential = credentials;
            resourceClient.ClientCredentials.Windows.ClientCredential = credentials;


            var it = new IdmNetClient(searchClient, factoryClient, resourceClient);
            return it;
        }


        /// <summary>
        /// Get an environment variable
        /// </summary>
        /// <param name="environmentSettingName">Name of the environment variable</param>
        /// <returns>Environment variable value</returns>
        public static string GetEnvironmentSetting(string environmentSettingName)
        {
            var environmentSettingValue = Environment.GetEnvironmentVariable(environmentSettingName);
            if (environmentSettingValue == null)
            {
                environmentSettingValue = ConfigurationManager.AppSettings[environmentSettingName];
                if (environmentSettingValue == null)
                {
                    throw new ApplicationException("Missing Environment Variable: " + environmentSettingName);
                }
            }
            return environmentSettingValue;
        }

    }
}
