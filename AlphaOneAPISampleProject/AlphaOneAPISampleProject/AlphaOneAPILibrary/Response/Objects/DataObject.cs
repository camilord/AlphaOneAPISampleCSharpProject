using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Response.Objects
{
    class DataObject
    {
        public String Pagination { set; get; }

        public Int64 Offset { set; get; }

        public Int64 MaxPerQuery { set; get; }

        public Int64 Pages { set; get; }

        public Int64 TotalProjects { set; get; }

        public ProjectListItemObject[] List { set; get; }
    }
}
