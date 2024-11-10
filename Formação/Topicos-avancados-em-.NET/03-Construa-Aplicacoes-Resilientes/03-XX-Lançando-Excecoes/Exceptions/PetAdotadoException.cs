namespace _03_XX_Lançando_Excecoes.Exceptions;

public class PetAdotadoException : Exception
{
    public PetAdotadoException(string? mensagem) : base(mensagem)
    {
    }
}