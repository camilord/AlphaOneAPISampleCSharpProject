using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.ProjectList
{
    interface ProjectListInterface
    {
        ProjectListResponse getList(int offset = 0);
    }
}
