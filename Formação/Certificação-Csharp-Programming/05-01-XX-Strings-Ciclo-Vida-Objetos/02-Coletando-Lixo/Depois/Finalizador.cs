﻿using System;

namespace _05_01_XX_Strings_Ciclo_Vida_Objetos.Depois
{
    class Finalizador : IAulaItem
    {
        public void Executar()
        {
            for (int i = 0; i < 100; i++)
            {
                Livro livro = new Livro();
            }

            GC.Collect();

            Console.ReadKey();
        }
    }

    class Livro
    {
        static int UltimoId = 0;
        public string Introducao { get; set; }
        public string Texto { get; set; }
        public string Conclusao { get; set; }
        public int Id { get; }

        public Livro()
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
