using System;

namespace _05_XX_Integrando_Aplicacao_Banco_Dados.Infraestrutura.Testes.DTO
{
    public class PixDTO
    {
        private Guid chave;
        private double saldo;
        public Guid Chave { get => chave; set => chave = value; }
        public double Saldo { get => saldo; set => saldo = value; }
    }
}