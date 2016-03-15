using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaunchDarkly.Client;

namespace DarklyLaunchTest.Controllers
{
    public class DarkLaunchConfigurator
    {
        private static readonly DarkLaunchConfigurator Instance = new DarkLaunchConfigurator();
        private LdClient ldClient;

        private DarkLaunchConfigurator()
        {
        }

        public LdClient GetLdClient()
        {
            if (ldClient == null)
            {
                ldClient = new LdClient("sdk-dbcb098d-e73c-4e8c-a8ad-be496789dfa9");
            }
            return ldClient;
        }

        public static DarkLaunchConfigurator GetInstance()
        {
            return Instance;
        }
    }
}