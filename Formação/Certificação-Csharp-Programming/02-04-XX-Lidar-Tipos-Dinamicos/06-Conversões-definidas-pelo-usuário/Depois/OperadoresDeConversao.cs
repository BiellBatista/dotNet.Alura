using System;

namespace _02_04_XX_Lidar_Tipos_Dinamicos.Depois
{
    class OperadoresDeConversao : IAulaItem
    {
        public void Executar()
        {
            ///<image url="$(ProjectDir)img14.png" />

            AnguloEmGraus anguloEmGraus = 45; //chamando o método de conversão
            Console.WriteLine(anguloEmGraus);

            AnguloEmRadianos anguloEmRadianos = (AnguloEmRadianos)15; //chamando o método de conversão explicita
            Console.WriteLine(anguloEmRadianos);

            double graus = anguloEmGraus; //chamando o método de conversão

            anguloEmRadianos = anguloEmGraus; //chamando o método de conversão
            anguloEmGraus = anguloEmRadianos; //chamando o método de conversão
            System.Console.WriteLine($"anguloEmGraus: {anguloEmGraus}");
            System.Console.WriteLine($"anguloEmRadianos: {anguloEmRadianos}");
        }
    }

    public struct AnguloEmRadianos
    {
        public double Radianos { get; }

        public AnguloEmRadianos(double radianos)
        {
            this.Radianos = radianos;
        }

        //este método de conversão faz uma conversão implicita. Não preciso colocar um casting
        public static implicit operator AnguloEmRadianos(AnguloEmGraus graus)
        {
            return new AnguloEmRadianos(graus.Graus * System.Math.PI / 180);
        }

        //este método de conversão faz uma conversão epxlicita. Ou seja, preciso realizar um casting(linha 14)
        public static explicit operator AnguloEmRadianos(double radianos)
        {
            return new AnguloEmRadianos(radianos);
        }

        public static implicit operator double(AnguloEmRadianos radianos)
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

        public AnguloEmGraus(double graus) { this.Graus = graus; }

        public static implicit operator AnguloEmGraus(AnguloEmRadianos radianos)
        {
            return new AnguloEmGraus(radianos.Radianos * 180 / System.Math.PI);
        }

        //criando um método que irá converter os objetos
        public static implicit operator AnguloEmGraus(double graus)
        {
            return new AnguloEmGraus(graus);
        }

        public static implicit operator double(AnguloEmGraus graus)
        {
            return graus.Graus;
        }

        public override string ToString()
        {
            return string.Format("{0} graus", this.Graus);
        }
    }
}
