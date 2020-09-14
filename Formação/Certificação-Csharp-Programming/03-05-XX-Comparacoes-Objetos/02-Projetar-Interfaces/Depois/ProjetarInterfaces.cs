using System;

namespace _03_05_XX_Comparacoes_Objetos.Depois
{
    class ProjetarInterfaces : IAulaItem
    {
        public void Executar()
        {
            IEletrodomestico eletro1 = new Televisao();
            IEletrodomestico eletro2 = new Abajur();
            IEletrodomestico eletro3 = new Lanterna();
            IEletrodomestico eletro4 = new Radio();
        }
    }

    interface IEletrodomestico
    {
        event EventHandler Ligou;
        event EventHandler Desligou;

        void Desligar();
        void Ligar();
    }

    interface IIluminacao
    {
        double PotenciaDaLampada { get; set; }
    }

    interface IRadioReceptor
    {
        double Frequencia { get; set; }
    }

    class Televisao : IEletrodomestico, IRadioReceptor
    {
        public event EventHandler Ligou;
        public event EventHandler Desligou;

        public double Frequencia { get; set; }

        public void Desligar()
        {
        }

        public void Ligar()
        {
            if (Ligou != null)
            {
                Ligou(this, new EventArgs());
            }
        }
    }

    class Abajur : IEletrodomestico, IIluminacao
    {
        public double PotenciaDaLampada { get; set; }

        public event EventHandler Ligou;
        public event EventHandler Desligou;

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

        public event EventHandler Ligou;
        public event EventHandler Desligou;

        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }

    class Radio : IEletrodomestico, IRadioReceptor
    {
        public event EventHandler Ligou;
        public event EventHandler Desligou;

        public double Frequencia { get; set; }

        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }
}
