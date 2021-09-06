using System;
using System.IO;
using System.Text;

namespace _08_07_XX_Consumindo_Servicos_Interpretando_Dados.Depois
{
    public class AcessandoWebFormaAssincrona05 : IAulaItem //Acesso assíncrono a arquivos
    {
        public void Executar()
        {
            //TAREFA:   IMPLEMENTAR ACESSO ASSÍNCRONO A ARQUIVOS,
            //          TANTO NA LEITURA QUANTO NA GRAVAÇÃO

            // GRAVANDO UM ARQUIVO
            using (FileStream fluxoSaida = new FileStream("ArquivoSaida.txt", FileMode.Create, FileAccess.Write))
            {
                string mensagemSaida = "Olá, Alura!";

                byte[] array = Encoding.UTF8.GetBytes(mensagemSaida);
                int posicao = 0;
                int tamanho = mensagemSaida.Length;
                fluxoSaida.Write(array, posicao, tamanho);
            }

            // LENDO UM ARQUIVO
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