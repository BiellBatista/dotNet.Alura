namespace _08_04_XX_Inserindo_Valores_Banco.Validador;

public abstract class Valida : IValidavel
{
    private readonly Erros erros = new();
    public bool EhValido => erros.Count() == 0;
    public Erros Erros => erros;

    protected abstract void Validar();
}