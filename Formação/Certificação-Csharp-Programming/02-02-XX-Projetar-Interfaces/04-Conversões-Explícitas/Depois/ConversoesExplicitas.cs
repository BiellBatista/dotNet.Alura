using System;

namespace _02_02_XX_Projetar_Interfaces.Depois
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

    interface IAnimal { }

    class Animal : IAnimal
    {
        public string Nome { get; set; }

        public void Beber()
        {
            Console.WriteLine("Animal.Beber");
        }

        public virtual void Comer()
        {
            Console.WriteLine("Animal.Comer");
        }

        public void Andar()
        {
            Console.WriteLine("Animal.Andar");
        }
    }

    class Gato : Animal
    {
        public new void Beber()
        {
            Console.WriteLine("Gato.Beber");
        }

        public override void Comer()
        {
            Console.WriteLine("Gato.Comer");
        }

        //a palavra new deixa claro para o compilador que eu quero ter dois métodos, mas o Andar da classe Gato não sobrescreve o Andar da classe Animal
        //não posso usar new na classe Base (animal)
        public new void Andar()
        {
            Console.WriteLine("Gato.Andar");
        }
    }
}
