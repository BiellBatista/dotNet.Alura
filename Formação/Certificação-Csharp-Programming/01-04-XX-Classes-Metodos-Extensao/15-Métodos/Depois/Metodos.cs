using System;

namespace _01_04_XX_Classes_Metodos_Extensao.Depois
{
    class Metodos : IAulaItem
    {
        public void Executar()
        {
            Retangulo retangulo = new Retangulo(12, 10);

            Retangulo outroRetangulo = new Retangulo(10, 10);
            Console.WriteLine(retangulo.Semelhante(outroRetangulo.Altura, outroRetangulo.Largura));

            outroRetangulo = new Retangulo(5, 6);
            Console.WriteLine(retangulo.Semelhante(outroRetangulo));

            outroRetangulo = new Retangulo(8, 6);
            Console.WriteLine(Retangulo.Semelhante(retangulo, outroRetangulo));
        }
    }

    class Retangulo
    {
        public double Altura { get; set; }
        public double Largura { get; set; }

        public Retangulo(double altura, double largura)
        {
            Altura = altura;
            Largura = largura;

            Console.WriteLine($"altura: {altura}, largura: {largura}");
        }

        public double GetArea()
        {
            return Altura * Largura;
        }

        internal bool Semelhante(double outroRetanguloAltura, double outroRetanguloLargura)
        {
            return
                ((Largura / Altura) == /*proporção deste retângulo*/
                (outroRetanguloLargura / outroRetanguloAltura)) /*proporção do outro retângulo*/
                ||
                ((Altura / Largura) == /*compara a proporção inversa*/
                (outroRetanguloLargura / outroRetanguloAltura));
        }

        internal bool Semelhante(Retangulo outroRetangulo)
        {
            return
                ((Largura / Altura) == /*proporção deste retângulo*/
                (outroRetangulo.Largura / outroRetangulo.Altura)) /*proporção do outro retângulo*/
                ||
                ((Altura / Largura) == /*compara a proporção inversa*/
                (outroRetangulo.Largura / outroRetangulo.Altura));
        }

        internal static bool Semelhante(Retangulo retangulo, Retangulo outroRetangulo)
        {
            return
                ((retangulo.Largura / retangulo.Altura) == /*proporção deste retângulo*/
                (outroRetangulo.Largura / outroRetangulo.Altura)) /*proporção do outro retângulo*/
                ||
                ((retangulo.Altura / retangulo.Largura) == /*compara a proporção inversa*/
                (outroRetangulo.Largura / outroRetangulo.Altura));
        }
    }
}
