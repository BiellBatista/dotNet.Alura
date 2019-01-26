using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_XX_XX_EntradaSaídaStreams
{
    partial class Program
    {
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "456,78945,4785.50,Gustavo Santos";
                var encoding = Encoding.UTF8; //encoding que irei usar para tranformar a cadeia de string
                var bytes = encoding.GetBytes(contaComoString); //transformando para byte

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CiarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            //using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew)) //Se o arquivo existir, retorna uma exceção
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                var contaComoString = "456,78945,4785.50,Gustavo Santos";

                escritor.Write(contaComoString);
            }
        }
    }
}
