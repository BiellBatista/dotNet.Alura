using _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Dados;
using _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Services.Handlers
{
    /**
     * Para novas funcionalidades, devo sempre procurar criar novas classes que representem essa funcionalidade.
     * Porém, se for necessário implementar métodos já existentes, devo chamar a classe já existente (default)
     */
    public class ArquivamentoAdminService : IAdminService
    {
        IAdminService _defaultService;

        public ArquivamentoAdminService(ILeilaoDao dao) => _defaultService = new DefaultAdminService(dao);

        public void CadastraLeilao(Leilao leilao) => _defaultService.CadastraLeilao(leilao);
        public IEnumerable<Categoria> ConsultaCategorias() => _defaultService.ConsultaCategorias();
        public Leilao ConsultaLeilaoPorId(int id) => _defaultService.ConsultaLeilaoPorId(id);
        //o método ConsultaLeiloes está utlizando o padrao Decorator, pois estou adicionando uma nova regra (Where) em uma funcionalidade já existente (defaultService)
        public IEnumerable<Leilao> ConsultaLeiloes() => _defaultService.ConsultaLeiloes().Where(l => l.Situacao != SituacaoLeilao.Arquivado);
        public void FinalizaPregaoDoLeilaoComId(int id) => _defaultService.FinalizaPregaoDoLeilaoComId(id);
        public void IniciaPregaoDoLeilaoComId(int id) => _defaultService.IniciaPregaoDoLeilaoComId(id);
        public void ModificaLeilao(Leilao leilao) => _defaultService.ModificaLeilao(leilao);

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _defaultService.ModificaLeilao(leilao);
            }
        }
    }
}
