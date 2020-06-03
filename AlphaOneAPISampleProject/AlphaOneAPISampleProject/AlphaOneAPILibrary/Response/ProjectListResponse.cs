using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Response
{
    class ProjectListResponse
    {
        public String Result { get; set; }
        public String Message { get; set; }
        public String Timestamp { get; set; }
        public DataObject Data { get; set; }
    }
}
