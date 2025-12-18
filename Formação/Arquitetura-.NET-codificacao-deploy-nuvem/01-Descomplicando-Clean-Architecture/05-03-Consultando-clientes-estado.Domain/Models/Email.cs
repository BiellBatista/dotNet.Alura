using System.Text.RegularExpressions;

namespace _05_03_Consultando_clientes_estado.Domain.Models;

public class Email
{
    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public Email(string value)
    {
        // validação
        if (!EmailRegex.IsMatch(value))
        {
            throw new ArgumentException("E-mail inválido.");
        }

        Value = value;
    }

    public string Value { get; }
}