using System;

namespace _02_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes.DTO
{
    public class PixDTO
    {
        private Guid chave;
        private double saldo;
        public Guid Chave { get => chave; set => chave = value; }
        public double Saldo { get => saldo; set => saldo = value; }
    }
}