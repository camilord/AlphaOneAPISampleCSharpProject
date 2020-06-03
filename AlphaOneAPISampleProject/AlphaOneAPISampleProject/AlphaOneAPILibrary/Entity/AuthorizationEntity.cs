using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity
{
    class AuthorizationEntity
    {
        private static String Username;
        private static String SessionKey;
        private static String BaseUrl;

        public AuthorizationEntity(String base_url, String uname, String session_key)
        {
            Username = uname;
            SessionKey = session_key;
            BaseUrl = base_url;
        }

        public String getUsername()
        {
            return Username;
        }

        public String getSessionKey()
        {
            return SessionKey;
        }

        public String getBaseUrl()
        {
            return BaseUrl;
        }
    }
}
