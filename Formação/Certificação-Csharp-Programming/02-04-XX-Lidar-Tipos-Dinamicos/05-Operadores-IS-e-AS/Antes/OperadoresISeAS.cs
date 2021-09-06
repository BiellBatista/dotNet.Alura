using System;

namespace _02_04_XX_Lidar_Tipos_Dinamicos.Antes
{
    internal class OperadoresISeAS : IAulaItem
    {
        public void Executar()
        {
            Animal animal = new Animal();
            Gato gato = new Gato();
            Cliente cliente = new Cliente("José da Silva", 30);
        }

        public void Alimentar(object obj)
        {
            Animal animal = (Animal)obj;
            animal.Beber();
            animal.Comer();
        }
    }

    internal class Cliente
    {
        public Cliente(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}";
        }
    }

    internal interface IAnimal
    { }

    internal class Animal : IAnimal
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

    internal class Gato : Animal
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