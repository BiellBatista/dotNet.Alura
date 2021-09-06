using System;

namespace _03_04_XX_Classe_Base.Antes
{
    internal class ProjetarInterfaces : IAulaItem
    {
        public void Executar()
        {
            Televisao eletro1 = new Televisao();
            Abajur eletro2 = new Abajur();
            Lanterna eletro3 = new Lanterna();
            Radio eletro4 = new Radio();
        }
    }

    internal class Televisao
    {
        public event EventHandler Ligou;

        public event EventHandler Desligou;

        public double FrequenciaDoCanal { get; set; }

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

    internal class Abajur
    {
        public int PotenciaDaLampada { get; set; }

        public event EventHandler Ligou;

        public event EventHandler Desligou;

        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }

    internal class Lanterna
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

    internal class Radio
    {
        public event EventHandler Ligou;

        public event EventHandler Desligou;

        public double FrequenciaDaEstacao { get; set; }

        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }
}