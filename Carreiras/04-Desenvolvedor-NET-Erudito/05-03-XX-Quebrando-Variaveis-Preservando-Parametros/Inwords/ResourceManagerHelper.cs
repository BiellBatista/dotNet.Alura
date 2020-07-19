using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Inwords
{
    class ResourceManagerHelper
    {
        private readonly ResourceManager resourceManager;
        private static ResourceManagerHelper instance;
        private ResourceManagerHelper()
        {
            resourceManager = new ResourceManager(@"_05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Properties.messages_pt_BR",
             System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("_05_03_XX_Quebrando_Variaveis_Preservando_Parametros")));
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
