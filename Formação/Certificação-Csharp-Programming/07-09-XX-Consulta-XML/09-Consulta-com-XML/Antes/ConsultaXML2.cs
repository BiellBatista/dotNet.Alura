﻿using System;

namespace _07_09_XX_Consulta_XML.Antes
{
    public class ConsultaXML2 : IAulaItem
    {
        public void Executar()
        {
            string xmlText =
            "<Filmes>" +
                "<Filme>" +
                    "<Diretor>Quentin Tarantino</Diretor>" +
                    "<Titulo>Pulp Fiction</Titulo>" +
                    "<Minutos>154</Minutos>" +
                "</Filme>" +
                "<Filme>" +
                    "<Diretor>James Cameron</Diretor>" +
                    "<Titulo>Avatar</Titulo>" +
                    "<Minutos>162</Minutos>" +
                "</Filme>" +
            "</Filmes>";

            Console.ReadKey();
        }
    }
}