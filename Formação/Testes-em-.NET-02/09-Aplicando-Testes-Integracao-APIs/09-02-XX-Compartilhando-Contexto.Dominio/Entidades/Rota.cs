using _09_02_XX_Compartilhando_Contexto.Dominio.Validacao;

namespace _09_02_XX_Compartilhando_Contexto.Dominio.Entidades;

public class Rota : Valida
{
    public int Id { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }

    public Rota()
    {
    }

    public Rota(string origem, string destino)
    {
        Origem = origem;
        Destino = destino;
        Validar();
    }

    protected override void Validar()
    {
        if (Origem is null || Origem.Equals(string.Empty))
        {
            Erros.RegistrarErro("A rota não pode possuir uma origem nula ou vazia.");
        }
        else if (Destino is null || Destino.Equals(string.Empty))
        {
            Erros.RegistrarErro("A rota não pode possuir um destino nulo ou vazio.");
        }
    }
}