using _02_XX_Excecoes_ADOPET_API.Dtos;
using _02_XX_Excecoes_ADOPET_API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace _02_XX_Excecoes_ADOPET_API.Models;

public class Pet
{
    [Key]
    [Required]
    public long Id { get; set; }

    public string Nome { get; set; }
    public int Idade { get; set; }
    public TipoPet Tipo { get; set; }
    public bool Adotado { get; set; }
    public string Imagem { get; set; }
    public virtual Adocao Adocao { get; set; }

    public Pet()
    {
    }

    public Pet(CadastroPetDto dados, string nomeDaImagem)
    {
        Nome = dados.Nome;
        Idade = dados.Idade;
        Tipo = dados.Tipo;
        Imagem = nomeDaImagem;
        Adotado = false;
    }

    public void MarcarComoAdotado()
    {
        Adotado = true;
    }
}