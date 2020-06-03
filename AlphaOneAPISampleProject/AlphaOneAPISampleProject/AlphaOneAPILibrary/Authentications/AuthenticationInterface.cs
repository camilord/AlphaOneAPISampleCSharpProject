using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Authentications
{
    interface AuthenticationInterface
    {
        void Authenticate();

        void setAuthenticateEntity(AuthenticateEntity auth);

        String getResponse();
    }
}
