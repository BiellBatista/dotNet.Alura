namespace _05_XX_Usuario.API.Models
{
    public class Token
    {
        public Token(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}