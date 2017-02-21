using CRMWrapper.Support;
using Microsoft.Xrm.Sdk;
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
    public class CRMFacade
    {
        #region Constructor
        private CRMFacade() { }
        #endregion

        private Dictionary<string, Connection> CrmConnections = new Dictionary<string, Connection>();

        public static CRMFacade Instance = new CRMFacade();

        public bool CreateCRMConnection(AuthenticationProviderType authType, ConnectionCredentials connectionCredentials, int maxNumberOfConnections)
        {
            try
            {
                var crmConnection = new Connection(maxNumberOfConnections, maxNumberOfConnections);
                crmConnection.CreateCrmConnection(authType, connectionCredentials);
                CrmConnections[connectionCredentials.OrganizationUrl] = crmConnection;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CrmServiceClient this[string organizationUrl] 
        {
            get
            {
                try
                {
                    CrmConnections[organizationUrl].Wait();
                    return CrmConnections[organizationUrl].ServiceClient;
                }
                finally
                {
                    CrmConnections[organizationUrl].Release();
                }
            }
        }

        public OrganizationResponse Execute(string organizationUrl, OrganizationRequest request)
        {
            try
            {
                CrmConnections[organizationUrl].Wait();
                OrganizationResponse response = CrmConnections[organizationUrl].ServiceClient.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
