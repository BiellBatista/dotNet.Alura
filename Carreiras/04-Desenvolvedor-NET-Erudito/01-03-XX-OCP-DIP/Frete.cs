﻿namespace _01_03_XX_OCP_DIP
{
    public class Frete : IServicoDeEntrega
    {
        public double Para(string cidade)
        {
            if ("SAO PAULO".Equals(cidade.ToUpper()))
            {
                return 15;
            }
            else
            {
                return 30;
            }
        }
    }
}