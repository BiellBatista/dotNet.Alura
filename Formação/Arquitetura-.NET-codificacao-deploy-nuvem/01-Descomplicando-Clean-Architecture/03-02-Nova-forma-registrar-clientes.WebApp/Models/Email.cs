using System.Text.RegularExpressions;

namespace _03_02_Nova_forma_registrar_clientes.WebApp.Models;

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
