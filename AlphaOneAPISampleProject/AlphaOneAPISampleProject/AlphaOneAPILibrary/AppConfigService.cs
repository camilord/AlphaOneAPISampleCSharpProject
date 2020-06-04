using AlphaOneAPISampleProject.AlphaOneAPILibrary.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary
{
    class AppConfigService
    {
        public AppConfig getConfiguration()
        {
            string filename = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\AlphaOneAPISampleProject\AppConfig.json";

            if (File.Exists(filename))
            {
                try
                {
                    String json_data = File.ReadAllText(filename);
                    AppConfig config = JsonConvert.DeserializeObject<AppConfig>(json_data);

                    return config;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception("Error! Unable to parse as JSON in the AppConfig.json.");
                }
            }
            else
            {
                throw new IOException("Error! AppConfig.json not found.");
            }
        }
    }
}
