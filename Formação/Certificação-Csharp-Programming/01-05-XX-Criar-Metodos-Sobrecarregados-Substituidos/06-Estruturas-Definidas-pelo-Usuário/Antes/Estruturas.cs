using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Antes
{
    class Estruturas : IAulaItem
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
        }
    }
}
