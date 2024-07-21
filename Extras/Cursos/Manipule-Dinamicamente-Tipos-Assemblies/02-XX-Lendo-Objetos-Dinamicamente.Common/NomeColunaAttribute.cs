namespace _02_XX_Lendo_Objetos_Dinamicamente.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NomeColunaAttribute : Attribute
    {
        public string Header { get; }

        public NomeColunaAttribute(string header)
        {
            Header = header;
        }
    }
}