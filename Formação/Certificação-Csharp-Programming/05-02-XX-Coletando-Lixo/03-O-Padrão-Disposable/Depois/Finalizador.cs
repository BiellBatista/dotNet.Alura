using System;

namespace _05_02_XX_Coletando_Lixo.Depois
{
    class Finalizador2 : IAulaItem
    {
        public void Executar()
        {
            for (int i = 0; i < 100; i++)
            {
                Livro2 livro = new Livro2();
            }

            GC.Collect();

            Console.ReadKey();
        }
    }

    class Livro2
    {
        static int UltimoId = 0;
        public string Introducao { get; set; }
        public string Texto { get; set; }
        public string Conclusao { get; set; }
        public int Id { get; }

        public Livro2()
        {
            UltimoId++;
            Id = UltimoId;
            //Trace.WriteLine("Livro " + Id + " está sendo criado");
        }

        //~Livro()
        //{
        //    //LIBERAR SOMENTE OS RECURSOS NÃO-GERENCIADOS
        //    Trace.WriteLine("Livro " + Id + " está sendo finalizado");
        //}
    }
}
