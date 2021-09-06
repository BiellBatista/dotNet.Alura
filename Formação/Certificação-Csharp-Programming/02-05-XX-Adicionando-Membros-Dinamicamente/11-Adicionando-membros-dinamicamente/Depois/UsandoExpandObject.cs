using Newtonsoft.Json;
using System;
using System.Dynamic;

namespace _02_05_XX_Adicionando_Membros_Dinamicamente.Depois
{
    internal class UsandoExpandObject : IAulaItem
    {
        public void Executar()
        {
            string json = "{\"De\": \"Paulo Silveira\"," +
                "\"Para\": \"Guilherme Silveira\"}";

            //o ExpandoObject cria um objeto, em tempo de execução, com base no json deserializado
            dynamic mensagem = JsonConvert.DeserializeObject<ExpandoObject>(json);

            //criando propriedade, em tempo de execução
            mensagem.Texto = "Olá, " + mensagem.Para;

            EnviarMensagem(mensagem);

            //criando método dinamicamente, em tempo de execução
            mensagem.Inverter = new Action(() =>
            {
                var aux = mensagem.De;
                mensagem.De = mensagem.Para;
                mensagem.Para = aux;
                mensagem.Texto = "Olá, " + mensagem.Para;
            });

            mensagem.Inverter();
            EnviarMensagem(mensagem);
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

/**
 * Isso mesmo. Com uma nova instância da classe ExpandoObject, você pode adicionar dinamicamente membros, como propriedades e métodos. E o tipo da variável dynamic, faz com que as propriedades não gerem erros, pois não são verificadas em tempo de compilação.
 */