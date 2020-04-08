using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;
using CustomerPortal.Properties;


namespace b2c_ms_graph
{
    public class GraphClient
    {
        public static GraphServiceClient CreateGraphClient()
        {
            // Read application settings from appsettings.json (tenant ID, app ID, client secret, etc.)
            // AppSettings config = AppSettingsFile.ReadFromJsonFile();

            // Initialize the client credential auth provider
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(Settings.Default.ManagementAppID)
                .WithTenantId(Settings.Default.TenantURL)
                .WithClientSecret(Settings.Default.ManagementAppClientSecret)
                .Build();
            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);

            // Set up the Microsoft Graph service client with client credentials
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            return graphClient;
        }

    }
}