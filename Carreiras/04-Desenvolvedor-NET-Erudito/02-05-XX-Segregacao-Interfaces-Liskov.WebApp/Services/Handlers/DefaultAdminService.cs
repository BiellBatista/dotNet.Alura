﻿using System;
using System.Collections.Generic;
using _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Dados;
using _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Models;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        private readonly ILeilaoDao _dao;
        private readonly ICategoriaDao _categDao;

        public DefaultAdminService(ILeilaoDao dao, ICategoriaDao categDao)
        {
            _dao = dao;
            _categDao = categDao;
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _categDao.BuscarTodos();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _dao.BuscarTodos();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _dao.BuscarPorId(id);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _dao.Incluir(leilao);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _dao.Alterar(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                _dao.Excluir(leilao);
            }
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = _dao.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _dao.Alterar(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = _dao.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _dao.Alterar(leilao);
            }
        }
    }
}
