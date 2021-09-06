using System;
using System.Diagnostics;

namespace _05_03_XX_O_Padrao_Disposable.Antes
{
    internal class Finalizador : IAulaItem
    {
        public void Executar()
        {
            for (int i = 0; i < 100; i++)
            {
                Livro livro = new Livro();
            }

            Console.ReadKey();
        }
    }

    internal class Livro
    {
        private static int UltimoId = 0;
        public string Introducao { get; set; }
        public string Texto { get; set; }
        public string Conclusao { get; set; }
        public int Id { get; }

        public Livro()
        {
            UltimoId++;
            Id = UltimoId;
            Trace.WriteLine("Livro " + Id + " está sendo criado");
        }
    }
}