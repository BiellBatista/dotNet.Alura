﻿using System;

namespace _05_XX_MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static void MainSync(string[] args)
        {
            Console.WriteLine("Esperando 10 segundos ....");
            System.Threading.Thread.Sleep(10000);
            Console.WriteLine("Esperei 10 segundos ....");
        }
    }
}
