using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Response
{
    class AuthenticationResponse
    {
        public String status { get; set; }
        public String session_key { get; set; }
        public String message { get; set; }
    }
}
