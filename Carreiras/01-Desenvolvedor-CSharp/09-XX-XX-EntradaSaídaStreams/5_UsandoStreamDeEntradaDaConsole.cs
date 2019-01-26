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
        static void UsarStreamDeEntrada()
        {
            using (var fs = Console.OpenStandardInput())
            using (var fluxoDeArquivo = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];
                //quando o arquivo fechar, o conteúdo do buffer será gravado nele
                while (true)
                {
                    var bytesLidos = fs.Read(buffer, 0, 1024);
                    fluxoDeArquivo.Write(buffer, 0, bytesLidos);
                    fluxoDeArquivo.Flush();

                    Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
                }
            }
        }
    }
}
