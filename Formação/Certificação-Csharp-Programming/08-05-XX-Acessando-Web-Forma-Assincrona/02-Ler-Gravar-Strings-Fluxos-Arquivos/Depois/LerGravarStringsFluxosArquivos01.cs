using System;
using System.IO;
using System.Text;

namespace _08_05_XX_Acessando_Web_Forma_Assincrona.Depois
{
    public class LerGravarStringsFluxosArquivos01 : IAulaItem
    {
        public void Executar()
        {
            // GRAVANDO UM ARQUIVO
            using (FileStream fluxoSaida = new FileStream("ArquivoSaida.txt", FileMode.Create, FileAccess.Write))
            {
                string mensagemSaida = "Olá, Alura!";
                byte[] array = Encoding.UTF8.GetBytes(mensagemSaida);
                int posicao = 0;
                int tamanho = mensagemSaida.Length;

                fluxoSaida.Write(array, posicao, tamanho);
            }

            using (FileStream fluxoEntrada = new FileStream("ArquivoSaida.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] bytesLidos = new byte[fluxoEntrada.Length];
                int posicao = 0;

                fluxoEntrada.Read(bytesLidos, posicao, (int)fluxoEntrada.Length);

                string texto = Encoding.UTF8.GetString(bytesLidos);

                Console.WriteLine("Mensagem Lida: " + texto);
            }

            Console.ReadKey();
        }
    }
}