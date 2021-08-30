using System;
using System.IO;

namespace _08_03_XX_Gerenciando_Arquivos.Antes
{
    public class LerGravarStringsFluxosArquivos03 : IAulaItem //Trabalhando com arquivos comprimidos
    {
        public void Executar()
        {
            using (StreamWriter gravadorFluxo = new StreamWriter("ArquivoSaida.txt"))
            {
                gravadorFluxo.Write("Olá, Alura! (gravado com StreamWriter)");
            }

            using (StreamReader leitorFluxo = new StreamReader("ArquivoSaida.txt"))
            {
                string textoLido = leitorFluxo.ReadToEnd();
                Console.WriteLine("Texto lido: {0}", textoLido);
                Console.ReadKey();
            }
        }
    }
}