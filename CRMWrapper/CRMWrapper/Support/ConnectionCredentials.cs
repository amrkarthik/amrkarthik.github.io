using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMWrapper.Support
{
    public class ConnectionCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string OrganizationUrl { get; set; }
        public string Domain { get; set; }
        public string HomeRealmUrl { get; set; }

    }
}
