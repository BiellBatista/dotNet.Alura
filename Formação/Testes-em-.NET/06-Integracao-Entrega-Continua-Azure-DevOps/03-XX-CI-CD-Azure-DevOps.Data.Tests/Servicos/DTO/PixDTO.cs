using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_XX_CI_CD_Azure_DevOps.Data.Tests.Servicos.DTO
{
    public class PixDTO
    {
        private Guid chave;
        private double saldo;
        public Guid Chave { get => chave; set => chave = value; }
        public double Saldo { get => saldo; set => saldo = value; }
    }
}
