﻿using System;
using System.Collections.Generic;

namespace _04_06_XX_Bridges.Flyweight
{
    public class Piano
    {
        public void Toca(IList<INota> musica)
        {
            foreach (var nota in musica)
            {
                Console.Beep(nota.Frequencia, 300);
            }
        }
    }
}
