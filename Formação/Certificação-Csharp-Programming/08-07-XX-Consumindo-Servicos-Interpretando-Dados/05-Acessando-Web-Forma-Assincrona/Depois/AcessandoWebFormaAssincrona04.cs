﻿using System;
using System.Net.Http;

namespace _08_07_XX_Consumindo_Servicos_Interpretando_Dados.Depois
{
    public class AcessandoWebFormaAssincrona04 : IAulaItem //HttpClient
    {
        public void Executar()
        {
            //TAREFA:
            //Conectar-se site da caelum (http://www.caelum.com.br)
            //de forma ASSÍNCRONA, porém o código precisa rodar em
            //
            // - Aplicações Windows (Windows Forms, WPF)
            // - Aplicações Web (ASP.NET e ASP.NET Core)
            // - Xamarin (aplicativos de celular / tablet)
            // - Windows Universal Application Platform

            HttpClient cliente = new HttpClient();
            var textoDoSite = cliente.GetStringAsync("http://www.caelum.com.br").Result;

            Console.WriteLine(textoDoSite);
            Console.ReadKey();
        }
    }
}