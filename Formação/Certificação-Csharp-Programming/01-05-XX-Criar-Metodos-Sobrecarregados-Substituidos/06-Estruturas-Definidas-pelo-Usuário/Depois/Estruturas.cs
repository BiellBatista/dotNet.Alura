﻿using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class Estruturas : IAulaItem
    {
        public void Executar()
        {
            double Latitude1 = 13.78;
            double Longitude1 = 29.51;
            double Latitude2 = 40.23;
            double Longitude2 = 17.4;
            Console.WriteLine($"Latitude1 = {Latitude1}");
            Console.WriteLine($"Longitude1 = {Longitude1}");
            Console.WriteLine($"Latitude2 = {Latitude2}");
            Console.WriteLine($"Longitude2 = {Longitude2}");

            PosicaoGPS posicao1;
            posicao1.Latitude = 13.78;
            posicao1.Longitude = 29.51;

            PosicaoGPS posicao2 = new PosicaoGPS() { Latitude = 13.78, Longitude = 29.51 };
            PosicaoGPS posicao3 = new PosicaoGPS(13.78, 29.51);

            Console.WriteLine(posicao1);
        }
    }

    internal interface IGPS
    {
        bool EstaNoHemisferioNorte();
    }

    internal struct PosicaoGPS : IGPS
    {
        public double Latitude;
        public double Longitude;

        public PosicaoGPS(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"Latitude: {Latitude}, Longitude: {Longitude}";
        }

        public bool EstaNoHemisferioNorte()
        {
            return Latitude > 0;
        }
    }
}