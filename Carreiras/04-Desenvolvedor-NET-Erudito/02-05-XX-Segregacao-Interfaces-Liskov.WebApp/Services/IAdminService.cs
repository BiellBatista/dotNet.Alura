﻿using _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Models;
using System.Collections.Generic;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Services
{
    public interface IAdminService
    {
        IEnumerable<Categoria> ConsultaCategorias();
        IEnumerable<Leilao> ConsultaLeiloes();
        Leilao ConsultaLeilaoPorId(int id);
        void CadastraLeilao(Leilao leilao);
        void ModificaLeilao(Leilao leilao);
        void RemoveLeilao(Leilao leilao);
        void IniciaPregaoDoLeilaoComId(int id);
        void FinalizaPregaoDoLeilaoComId(int id);
    }
}
