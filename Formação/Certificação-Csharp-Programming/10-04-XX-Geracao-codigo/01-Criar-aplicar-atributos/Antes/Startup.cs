﻿using System;

namespace _10_04_XX_Geracao_codigo.Antes
{
    //Criar e aplicar atributos
    public class Startup : IAulaItem
    {
        public void Executar()
        {
            Relatorio relatorio = new Relatorio("Relatório de Vendas");

            relatorio.Imprimir();

            //TAREFA 1: Imprimir relatório detalhado OU resumido de acordo com a compilação

            //TAREFA 2: Verificar se a classe Venda define o atributo [Serializable]

            //TAREFA 3: Impedir a serialização do campo nome do comprador

            //TAREFA 4: Definir na classe Venda os formatos de impressão detalhada e resumida

            Console.ReadLine();
        }
    }
}