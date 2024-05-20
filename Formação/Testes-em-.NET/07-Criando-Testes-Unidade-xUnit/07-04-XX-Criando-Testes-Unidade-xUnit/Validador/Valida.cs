namespace _07_04_XX_Criando_Testes_Unidade_xUnit.Validador;

public abstract class Valida : IValidavel
{
    private readonly Erros erros = new();
    public bool EhValido => erros.Count() == 0;
    public Erros Erros => erros;

    protected abstract void Validar();
}