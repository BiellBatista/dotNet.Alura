namespace _01_03_XX_Criar_Tipos_Referencia.Depois
{
    internal class Interfaces : IAulaItem
    {
        public void Executar()
        {
            IEletrodomestico eletro1 = new Televisao();
            eletro1.Ligar();

            eletro1 = new Abajur();
        }
    }

    internal interface IEletrodomestico
    {
        void Ligar();

        void Desligar();
    }

    internal interface IIluminacao
    {
        double PotenciaDaLampada { get; set; }
    }

    internal class Televisao : IEletrodomestico
    {
        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }

    internal class Abajur : IEletrodomestico, IIluminacao
    {
        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }

    internal class Lanterna : IEletrodomestico, IIluminacao
    {
        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }
}