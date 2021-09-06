using System;

namespace _03_02_XX_Projetar_Interfaces.Depois
{
    internal class ProjetarInterfaces : IAulaItem
    {
        public void Executar()
        {
            IEletrodomestico eletro1 = new Televisao();
            IEletrodomestico eletro2 = new Abajur();
            IEletrodomestico eletro3 = new Lanterna();
            IEletrodomestico eletro4 = new Radio();
        }
    }

    internal interface IEletrodomestico
    {
        event EventHandler Ligou;

        event EventHandler Desligou;

        void Desligar();

        void Ligar();
    }

    internal interface IIluminacao
    {
        double PotenciaDaLampada { get; set; }
    }

    internal interface IRadioReceptor
    {
        double Frequencia { get; set; }
    }

    internal class Televisao : IEletrodomestico, IRadioReceptor
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

    internal class Abajur : IEletrodomestico, IIluminacao
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

    internal class Lanterna : IEletrodomestico, IIluminacao
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

    internal class Radio : IEletrodomestico, IRadioReceptor
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