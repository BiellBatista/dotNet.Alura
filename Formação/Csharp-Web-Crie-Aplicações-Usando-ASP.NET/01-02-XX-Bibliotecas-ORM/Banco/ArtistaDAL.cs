using _01_02_XX_Bibliotecas_ORM.Modelos;

namespace _01_02_XX_Bibliotecas_ORM.Banco;

internal class ArtistaDAL
{
    private readonly _01_02_XX_Bibliotecas_ORMContext context;

    public ArtistaDAL(_01_02_XX_Bibliotecas_ORMContext context)
    {
        this.context = context;
    }

    public IEnumerable<Artista> Listar()
    {
        return context.Artistas.ToList();
    }

    public void Adicionar(Artista artista)
    {
        context.Artistas.Add(artista);
        context.SaveChanges();
    }

    public void Atualizar(Artista artista)
    {
        context.Artistas.Update(artista);
        context.SaveChanges();
    }

    public void Deletar(Artista artista)
    {
        context.Artistas.Remove(artista);
        context.SaveChanges();
    }

    public Artista? RecuperarPeloNome(string nome)
    {
        return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}