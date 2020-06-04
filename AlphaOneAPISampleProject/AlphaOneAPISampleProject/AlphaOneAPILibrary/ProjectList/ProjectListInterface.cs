using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response;
using System;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.ProjectList
{
    interface ProjectListInterface
    {
        ProjectListResponse getList(int offset = 0);

        MarkResponse markDone(String alpha_id, String flag, String request_key);
    }
}
