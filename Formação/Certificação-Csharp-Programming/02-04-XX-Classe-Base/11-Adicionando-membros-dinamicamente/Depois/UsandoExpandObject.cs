using System;

namespace _02_04_XX_Classe_Base.Depois
{
    class UsandoExpandObject : IAulaItem
    {
        public void Executar()
        {
            string json = "{\"De\": \"Paulo Silveira\"," +
                "\"Para\": \"Guilherme Silveira\"}";
        }

        private void EnviarMensagem(dynamic msg)
        {
            Console.WriteLine($"De: {msg.De}");
            Console.WriteLine($"Para: {msg.Para}");
            Console.WriteLine($"Texto: {msg.Texto}");
            Console.WriteLine();
        }
    }
}
