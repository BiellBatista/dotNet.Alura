namespace _04_XX_Investigando_Assemblies.Common
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