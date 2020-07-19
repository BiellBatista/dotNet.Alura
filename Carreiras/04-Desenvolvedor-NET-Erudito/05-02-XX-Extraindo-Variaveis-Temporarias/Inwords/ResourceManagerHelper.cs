using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Inwords
{
    class ResourceManagerHelper
    {
        private readonly ResourceManager resourceManager;
        private static ResourceManagerHelper instance;
        private ResourceManagerHelper()
        {
            resourceManager = new ResourceManager(@"_05_02_XX_Extraindo_Variaveis_Temporarias.Properties.messages_pt_BR",
             System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("_05_02_XX_Extraindo_Variaveis_Temporarias")));
        }

        public static ResourceManagerHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new ResourceManagerHelper();
                return instance;
            }
        }

        public ResourceManager ResourceManager
        {
            get
            {
                return resourceManager;
            }
        }
    }
}
