using CRMWrapper.Resources;
using CRMWrapper.Support;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMWrapper
{
    internal class Connection: SemaphoreSlim
    {
        #region Constructors
        public Connection(int initialCount) : base(initialCount) { }

        public Connection(int initialCount, int maxCount) : base(initialCount, maxCount) { }
        #endregion

        public CrmServiceClient ServiceClient;

        internal void CreateCrmConnection(AuthenticationProviderType authType, ConnectionCredentials connectionCredentials)
        {
            try
            {
                string connectionString = GetConnectionString(authType, connectionCredentials);

                ServiceClient = new CrmServiceClient(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetConnectionString(AuthenticationProviderType authType, ConnectionCredentials connectionCredentials)
        {
            string connectionString = string.Empty;
            switch (authType)
            {
                case AuthenticationProviderType.None:
                    break;
                case AuthenticationProviderType.ActiveDirectory:
                    connectionString = string.Format(ConnectionStrings.ActiveDirectory,
                        connectionCredentials.OrganizationUrl,
                        connectionCredentials.Domain,
                        connectionCredentials.Username,
                        connectionCredentials.Password);
                    break;
                case AuthenticationProviderType.Federation:
                    connectionString = string.Format(ConnectionStrings.Federation,
                        connectionCredentials.OrganizationUrl,
                        connectionCredentials.HomeRealmUrl,
                        connectionCredentials.Domain,
                        connectionCredentials.Username,
                        connectionCredentials.Password);
                    break;
                case AuthenticationProviderType.LiveId:
                    break;
                case AuthenticationProviderType.OnlineFederation:
                    connectionString = string.Format(ConnectionStrings.OnlineFederation,
                        connectionCredentials.Username,
                        connectionCredentials.Password,
                        connectionCredentials.OrganizationUrl);
                    break;
                default:
                    break;
            }

            return connectionString;
        }
    }
}
