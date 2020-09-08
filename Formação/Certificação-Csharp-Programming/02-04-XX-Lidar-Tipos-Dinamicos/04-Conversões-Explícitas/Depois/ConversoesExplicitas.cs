using System;

namespace _02_04_XX_Lidar_Tipos_Dinamicos.Depois
{
    class ConversoesExplicitas : IAulaItem
    {
        public void Executar()
        {
            double divida = 1_234_567_890.123;
            double salario = 1_237.89;
            long copiaSalario = (long)salario;

            Animal animal = new Gato();
            Gato gato = (Gato)animal; //cast

            Console.WriteLine(gato.GetType());
        }
    }
}
