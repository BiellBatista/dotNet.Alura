﻿namespace _05_XX_ByteBank.Agencias.DAL
{
    public partial class Agencia
    {
        public override string ToString() =>
            $"{Numero} - {Nome}".Trim();
    }
}
