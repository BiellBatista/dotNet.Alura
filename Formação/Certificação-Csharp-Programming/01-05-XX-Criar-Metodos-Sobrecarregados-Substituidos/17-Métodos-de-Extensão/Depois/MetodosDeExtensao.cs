using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class MetodosDeExtensao : IAulaItem
    {
        public void Executar()
        {
            Impressora impressora = new Impressora("Este é\r\no meu documento");
            impressora.ImprimirDocumento();
            ImprimirDocumentoHTML(impressora.Documento);
            impressora.ImprimirDocumentoHTML();
            impressora.ImprimirDocumentoComResumo();
        }

        private void ImprimirDocumentoHTML(string documento)
        {
            Console.WriteLine($"<html><body>{documento}</body></html>");
        }
    }

    internal class Impressora
    {
        public string Documento { get; }

        public Impressora(string documento)
        {
            this.Documento = documento;
        }

        public void ImprimirDocumento()
        {
            Console.WriteLine();
            Console.WriteLine(Documento);
        }

        public void ImprimirDocumentoHTML()
        {
            Console.WriteLine($"<html><body>{Documento}</body></html>");
        }
    }

    internal static class ImpressoraExtensions
    {
        public static void ImprimirDocumentoHTML(this Impressora impressora)
        {
            Console.WriteLine($"<html><body>{impressora.Documento}</body></html>");
        }

        public static void ImprimirDocumentoComResumo(this Impressora impressora)
        {
            Console.WriteLine();
            Console.WriteLine($"{impressora.Documento}\r\nRESUMO\r\n======\r\nO documento tem: {impressora.Documento.Length} caracteres.");
        }
    }
}