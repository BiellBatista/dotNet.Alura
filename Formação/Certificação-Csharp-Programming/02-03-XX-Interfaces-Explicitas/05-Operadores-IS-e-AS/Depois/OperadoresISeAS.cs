using System;

namespace _02_03_XX_Interfaces_Explicitas.Depois
{
    class OperadoresISeAS : IAulaItem
    {
        public void Executar()
        {
            Animal animal = new Animal();
            Gato gato = new Gato();
            Cliente cliente = new Cliente("José da Silva", 30);
        }

        public void Alimentar(object obj)
        {
            //a palavra "as" converte o obj para animal com segurança
            Animal animal = obj as Animal;

            //Animal animal = null;
            //o obj é um animal?
            //if (obj is IAnimal)
            //{
            //    animal = (Animal)obj;
            //    animal.Beber();
            //    animal.Comer();
            //}
            //else

            if (obj is null)
            {
                Console.WriteLine("obj não é um animal");
                return;
            }

            animal.Beber();
            animal.Comer();

            //verificando se o obj é animal, caso sim, armazene o valor em animal2
            if (obj is Animal animal2)
            {
                animal2.Beber();
                animal2.Comer();
            }
        }
    }

    class Cliente
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
}
