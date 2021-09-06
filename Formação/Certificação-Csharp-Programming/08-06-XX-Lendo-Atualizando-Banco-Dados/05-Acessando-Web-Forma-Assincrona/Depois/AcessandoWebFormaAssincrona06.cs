using System;
using System.IO;
using System.Threading.Tasks;

namespace _08_06_XX_Lendo_Atualizando_Banco_Dados.Depois
{
    public class AcessandoWebFormaAssincrona06 : IAulaItem //File exceptions
    {
        public void Executar()
        {
            //TAREFA: CAPTURAR A EXCEÇÃO
            //GERADA POR UM MÉTODO ASSÍNCRONO

            byte[] dados = new byte[100];
            try
            {
                // nome do arquivo com caractere inválido ">"
                GravarBytesAsync("destino>.dat", dados).Wait();
            }
            catch (Exception writeException)
            {
                Console.WriteLine(writeException.Message);
                Console.WriteLine("escrita falhou");
            }

            Console.Read();
        }

        private async Task GravarBytesAsync(string nomeArquivo, byte[] items)
        {
            using (FileStream fluxoSaida = new FileStream(nomeArquivo, FileMode.OpenOrCreate, FileAccess.Write))
            {
                await fluxoSaida.WriteAsync(items, 0, items.Length);
            }
        }
    }
}