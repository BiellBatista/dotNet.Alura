﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02_XX_Acoplamento
{
    public class SAP : IAcaoAposGerarNota
    {
        public void Executar(NotaFiscal nf)
        {
            Console.WriteLine("Enviando nota para o SAP");
        }
    }
}
