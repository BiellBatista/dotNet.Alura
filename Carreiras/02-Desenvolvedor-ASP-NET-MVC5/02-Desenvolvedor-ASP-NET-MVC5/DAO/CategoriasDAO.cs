﻿using _02_Desenvolvedor_ASP_NET_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _02_Desenvolvedor_ASP_NET_MVC5.DAO
{
    public class CategoriasDAO
    {
        public void Adiciona(CategoriaDoProduto categoria)
        {
            using (var context = new EstoqueContext())
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }

        public IList<CategoriaDoProduto> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Categorias.ToList();
            }
        }

        public CategoriaDoProduto BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Categorias.Find(id);
            }
        }

        public void Atualiza(CategoriaDoProduto categoria)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(categoria).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}