using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class MetodosSubstituidos : IAulaItem
    {
        public void Executar()
        {
            Animal gato = new Gato() { Nome = "Bichano" };
            gato.Beber();
            gato.Comer();
            gato.Andar();

            Gato gata = new Gato() { Nome = "Pantera" };
            gata.Beber();
            gata.Comer();
            gata.Andar();
        }
    }

    internal class Animal
    {
        public String Nome { get; set; }

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