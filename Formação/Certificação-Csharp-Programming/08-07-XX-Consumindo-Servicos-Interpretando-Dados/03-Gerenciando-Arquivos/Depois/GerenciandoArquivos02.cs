﻿using System;
using System.IO;

namespace _08_07_XX_Consumindo_Servicos_Interpretando_Dados.Depois
{
    public class GerenciandoArquivos02 : IAulaItem //Stream exceptions
    {
        public void Executar()
        {
            try
            {
                string conteudo = File.ReadAllText("Arquivo.txt");
                Console.WriteLine("O conteúdo é: {0}", conteudo);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("O arquivo não foi encontrado.");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}