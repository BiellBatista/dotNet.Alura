﻿using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Antes
{
    internal class Metodos : IAulaItem
    {
        public void Executar()
        {
            Retangulo retangulo = new Retangulo(12, 10);
        }
    }

    internal class Retangulo
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

        private bool Semelhante(double outroRetanguloAltura, double outroRetanguloLargura)
        {
            return
                ((Largura / Altura) == /*proporção deste retângulo*/
                (outroRetanguloLargura / outroRetanguloAltura)) /*proporção do outro retângulo*/
                ||
                ((Altura / Largura) == /*compara a proporção inversa*/
                (outroRetanguloLargura / outroRetanguloAltura));
        }
    }
}