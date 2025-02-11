﻿using System;

namespace _02_04_XX_Lidar_Tipos_Dinamicos.Antes
{
    internal class OperadoresDeConversao : IAulaItem
    {
        public void Executar()
        {
            ///<image url="$(ProjectDir)img14.png" />

            AnguloEmGraus anguloEmGraus = AnguloEmGraus.Converte(45);
            Console.WriteLine(anguloEmGraus);

            AnguloEmRadianos anguloEmRadianos = AnguloEmRadianos.Converte(15);
            Console.WriteLine(anguloEmRadianos);

            double graus = AnguloEmGraus.Converte(anguloEmGraus);

            anguloEmRadianos = AnguloEmRadianos.Converte(anguloEmGraus);
            anguloEmGraus = AnguloEmGraus.Converte(anguloEmRadianos);
            Console.WriteLine($"anguloEmGraus: {anguloEmGraus}");
            Console.WriteLine($"anguloEmRadianos: {anguloEmRadianos}");
        }
    }

    public struct AnguloEmRadianos
    {
        public double Radianos { get; }

        public AnguloEmRadianos(double radianos)
        {
            this.Radianos = radianos;
        }

        public static AnguloEmRadianos Converte(AnguloEmGraus graus)
        {
            return new AnguloEmRadianos(graus.Graus * System.Math.PI / 180);
        }

        public static AnguloEmRadianos Converte(double radianos)
        {
            return new AnguloEmRadianos(radianos);
        }

        public static double Converte(AnguloEmRadianos radianos)
        {
            return radianos.Radianos;
        }

        public override string ToString()
        {
            return string.Format("{0} radianos", this.Radianos);
        }
    }

    public struct AnguloEmGraus
    {
        public double Graus { get; }

        public AnguloEmGraus(double graus)
        {
            this.Graus = graus;
        }

        public static AnguloEmGraus Converte(AnguloEmRadianos radianos)
        {
            return new AnguloEmGraus(radianos.Radianos * 180 / System.Math.PI);
        }

        public static AnguloEmGraus Converte(double graus)
        {
            return new AnguloEmGraus(graus);
        }

        public static double Converte(AnguloEmGraus graus)
        {
            return graus.Graus;
        }

        public override string ToString()
        {
            return string.Format("{0} graus", this.Graus);
        }
    }
}