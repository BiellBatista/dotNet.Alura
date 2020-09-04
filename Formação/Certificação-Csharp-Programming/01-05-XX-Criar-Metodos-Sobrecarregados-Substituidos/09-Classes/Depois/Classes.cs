using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    class Classes : IAulaItem
    {
        public void Executar()
        {
            ClassePosicaoGPS posicao1 = new ClassePosicaoGPS();
            posicao1.Latitude = 13.78;
            posicao1.Longitude = 29.51;
            posicao1 = new ClassePosicaoGPS() { Latitude = 13.78, Longitude = 29.51 };
            Console.WriteLine(posicao1);
        }
    }

    public class ClassePosicaoGPS : IGPS
    {
        public double Latitude;
        public double Longitude;

        public ClassePosicaoGPS()
        {

        }

        public ClassePosicaoGPS(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public bool EstaNoHemisferioNorte()
        {
            return Latitude > 0;

        }

        public override string ToString()
        {
            return $"Latitude: {Latitude}, Longitude: {Longitude}";
        }
    }

    public class PosicaoGPSComLeitura : ClassePosicaoGPS
    {
        private readonly DateTime dataLeitura;

        public PosicaoGPSComLeitura(double latitude, double longitude, DateTime dataLeitura) : base(latitude, longitude)
        {
            this.dataLeitura = dataLeitura;
        }
    }
}
