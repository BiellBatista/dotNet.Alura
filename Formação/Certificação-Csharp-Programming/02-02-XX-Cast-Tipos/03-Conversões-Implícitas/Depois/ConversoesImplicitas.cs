using System;

namespace _02_02_XX_Cast_Tipos.Depois
{
    class ConversoesImplicitas : IAulaItem
    {
        public void Executar()
        {
            int inteiro = 2_123_456_789;
            long inteiroLongo = inteiro;
            Console.WriteLine(inteiroLongo);

            Gato gato = new Gato();
            Animal animal = gato;
            Console.WriteLine(animal.GetType()); //o tipo é gato, pois animal armazena referencia para tipo gato
         
            IAnimal Ianimal = gato;
            Console.WriteLine(Ianimal.GetType()); //o tipo é gato, pois ianimal armazena referencia para tipo gato
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
