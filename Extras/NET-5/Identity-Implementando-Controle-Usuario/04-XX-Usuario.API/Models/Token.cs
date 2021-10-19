namespace _04_XX_Usuario.API.Models
{
    public class Token
    {
        public string Value { get; }

        public Token(string value)
        {
            Value = value;
        }
    }
}