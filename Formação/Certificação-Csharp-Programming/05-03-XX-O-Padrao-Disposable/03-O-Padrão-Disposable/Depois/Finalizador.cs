using System;

namespace _05_03_XX_O_Padrao_Disposable.Depois
{
    internal class Finalizador2 : IAulaItem
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

    internal class Livro2
    {
        private static int UltimoId = 0;
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

        //finalizador da classe. Devo colocar o tio (~) para indicar que isso é um finalizador
        //nunca devo criar um finalizador vázio ou um que eu não tenha recursos não gerenciados pelo .net
        //só devo declarar um finalizador, quando eu tiver um recurso não gerenciado pelo .net
        //~Livro()
        //{
        //    //LIBERAR SOMENTE OS RECURSOS NÃO-GERENCIADOS
        //    Trace.WriteLine("Livro " + Id + " está sendo finalizado");
        //}
    }
}