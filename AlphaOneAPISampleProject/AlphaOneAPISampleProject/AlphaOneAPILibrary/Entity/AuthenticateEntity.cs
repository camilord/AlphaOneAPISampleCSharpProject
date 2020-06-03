using System;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity
{
    class AuthenticateEntity
    {
        private static String base_url;
        private static String username;
        private static String password;

        public void setBaseUrl(String url)
        {
            base_url = url;
        }

        public String getBaseUrl()
        {
            return base_url;
        }

        public void setUsername(String uname)
        {
            username = uname;
        }

        public String getUsername()
        {
            return username;
        }

        public void setPassword(String passwd)
        {
            password = passwd;
        }

        public String getPassword()
        {
            return password;
        }
    }
}
