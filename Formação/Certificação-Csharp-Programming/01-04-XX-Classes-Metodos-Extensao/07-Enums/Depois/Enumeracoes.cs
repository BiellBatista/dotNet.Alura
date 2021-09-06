using System;

namespace _01_04_XX_Classes_Metodos_Extensao.Depois
{
    internal class Enumeracoes : IAulaItem
    {
        public void Executar()
        {
            const int Seg = 0;
            const int Ter = 1;
            const int Qua = 2;

            DiasDaSemana primeiroDia = DiasDaSemana.Seg;
            DiasDeTrabalho diasDeTrabalho = DiasDeTrabalho.Ter | DiasDeTrabalho.Qui | DiasDeTrabalho.Sex;

            Console.WriteLine(diasDeTrabalho);
        }
    }

    internal enum DiasDaSemana : long
    { Seg = 3, Ter = 10, Qua = 15, Qui, Sex, Sab, Dom }

    [Flags]
    internal enum DiasDeTrabalho
    { Seg = 0, Ter = 1, Qua = 2, Qui = 4, Sex = 8, Sab = 16, Dom = 32 }
}