namespace _01_04_XX_Classes_Metodos_Extensao.Depois
{
    class Interfaces : IAulaItem
    {
        public void Executar()
        {
            IEletrodomestico eletro1 = new Televisao();
            eletro1.Ligar();

            eletro1 = new Abajur();
        }
    }

    interface IEletrodomestico
    {
        void Ligar();
        void Desligar();
    }

    interface IIluminacao
    {
        double PotenciaDaLampada { get; set; }
    }

    class Televisao : IEletrodomestico
    {
        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }

    class Abajur : IEletrodomestico, IIluminacao
    {

        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }

    class Lanterna : IEletrodomestico, IIluminacao
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
