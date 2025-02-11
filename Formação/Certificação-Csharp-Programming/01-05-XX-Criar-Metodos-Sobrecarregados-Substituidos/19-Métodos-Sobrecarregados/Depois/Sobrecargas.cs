﻿using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class Sobrecargas : IAulaItem
    {
        public void Executar()
        {
            //VOLUME DO CUBO = lado ^ 3;
            int lado = 3;
            Console.WriteLine("VolumeDoCubo: " + Volume(lado));

            //VOLUME DO CILINDRO = altura * PI * raio ^ 2;
            double raio = 2;
            int altura = 10;
            Console.WriteLine("VolumeDoCilindro: " + Volume(altura, raio));

            //VOLUME DO PRISMA = largura * profundidade * altura
            long largura = 10;
            altura = 6;
            int profundidade = 4;
            Console.WriteLine("VolumeDoPrisma: " + Volume(largura, profundidade, altura));
        }

        private double Volume(double lado)
        {
            return Math.Pow(lado, 3);
        }

        private double Volume(double altura, double raio)
        {
            return altura * Math.PI * Math.Pow(raio, 2);
        }

        private double Volume(double largura, double profundidade, double altura)
        {
            return largura * profundidade * altura;
        }
    }
}