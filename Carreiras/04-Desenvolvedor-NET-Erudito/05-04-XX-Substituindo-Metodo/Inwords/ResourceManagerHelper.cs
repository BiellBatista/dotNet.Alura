using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace _05_04_XX_Substituindo_Metodo.Inwords
{
    class ResourceManagerHelper
    {
        private readonly ResourceManager resourceManager;
        private static ResourceManagerHelper instance;
        private ResourceManagerHelper()
        {
            resourceManager = new ResourceManager(@"_05_04_XX_Substituindo_Metodo.Properties.messages_pt_BR",
             System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("_05_04_XX_Substituindo_Metodo")));
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
