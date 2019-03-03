using _04_04_XX_ProgramaçãoParalelaParallelLINQ.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace _04_04_XX_ProgramaçãoParalelaParallelLINQ
{
    class Program
    {
        private const string Imagens = "Imagens";

        static void Main(string[] args)
        {
            // Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 1.1
            // Install-Package ZXing.Net (Biblioteca para criar QRCode)

            var barcodeWriter = new BarcodeWriter(); // classe responsavel por escrever na imagem
            barcodeWriter.Format = BarcodeFormat.QR_CODE; // forma do meu codigo
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 100,
                Height = 100
            }; // configurando tamanho do código

            //barcodeWriter.Write("Hello World!").Save("QRCode.jpg", ImageFormat.Jpeg); // armazenandoa string dentro do QRCode e salvando como uma imagem jpg
            if (!Directory.Exists(Imagens))
                Directory.CreateDirectory(Imagens);

            using (var contexto = new AluraTunesEntities())
            {
                var queryFaixas = from f in contexto.Faixas
                                  select f;
                var listaFaixas = queryFaixas.ToList();

                var stopwatch = Stopwatch.StartNew(); // cria a instância e inicia a contagem

                var queryCodigos = listaFaixas
                    .AsParallel() // paralelizando a tarefa de query
                    .Select(f => new
                    {
                        Arquivo = string.Format("{0}\\{1}.jpg", Imagens, f.FaixaId),
                        Imagem = barcodeWriter.Write(string.Format("aluratunes.com/faixa/{0}", f.FaixaId))
                    });

                var contagem = queryCodigos.Count();
                stopwatch.Stop();
                Console.WriteLine("Códigos gerados: {0} em {1} segundos", contagem, stopwatch.ElapsedMilliseconds);

                stopwatch = Stopwatch.StartNew(); // cria a instância e inicia a contagem
                //foreach (var item in queryCodigos)
                //    item.Imagem.Save(item.Arquivo, ImageFormat.Jpeg);

                queryCodigos.ForAll(item => item.Imagem.Save(item.Arquivo, ImageFormat.Jpeg));

                stopwatch.Stop();
                Console.WriteLine("Códigos gerados: {0} em {1} segundos", contagem, stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
