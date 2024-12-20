﻿using _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura.IoC;
using _05_05_XX_Service;
using _05_05_XX_Service.Cambio;
using _05_05_XX_Service.Cartao;
using System;
using System.Net;

namespace _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura
{
    public class CartaoServiceTesteContainer
    {
        public string ObterCartaoDeCreditoDeDestaque()
            => "Cartão de Crédito do Teste de Container";
        public string ObterCartaoDeDebitoDeDestaque()
            => "Cartão de Crédito do Teste de Container";
    }

    public class WebApplication
    {
        private readonly string[] _prefixos;
        private readonly IContainer _container = new ContainerSimples();

        public WebApplication(string[] prefixos)
        {
            if (prefixos == null)
                throw new ArgumentNullException(nameof(prefixos));
            _prefixos = prefixos;

            Configurar();
        }

        public void Iniciar()
        {
            while (true)
                ManipularRequisicao();
        }

        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in _prefixos)
                httpListener.Prefixes.Add(prefixo);

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var path = requisicao.Url.PathAndQuery;

            if (Utilidades.EhArquivo(path))
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(resposta, path);
            }
            else
            {
                var manipulador = new ManipuladorRequisicaoController(_container);
                manipulador.Manipular(resposta, path);
            }

            httpListener.Stop();
        }

        private void Configurar()
        {
            //_container.Registrar(typeof(ICambioService), typeof(CambioTesteService));
            //_container.Registrar(typeof(ICartaoService), typeof(CartaoServiceTeste));

            _container.Registrar<ICambioService, CambioTesteService>();
            _container.Registrar<ICartaoService, CartaoServiceTeste>();
        }
    }
}
