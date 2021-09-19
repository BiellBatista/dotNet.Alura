using System;

namespace _10_05_XX_Tipos_System_Reflection.Depois
{
    [Serializable]
    [FormatoResumido03("{0,-12}  {1,-12}  {2,12:C}  {3,-12}")]
    [FormatoDetalhado03("{0,-12}  {1,-12}  {2,12:C}  {3,-12}  {4,-20}  {5,-20}  {6,-20}  {7,-20}")]
    public class Venda03
    {
        public string Data { get; set; }
        public string Produto { get; set; }
        public int Preco { get; set; }
        public string TipoPagamento { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string DataCriacao { get; set; }
        public string UltimoLogin { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class FormatoResumido03Attribute : Attribute
    {
        public string Formato { get; }

        public FormatoResumido03Attribute(string formato)
        {
            Formato = formato;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class FormatoDetalhado03Attribute : Attribute
    {
        public string Formato { get; }

        public FormatoDetalhado03Attribute(string formato)
        {
            Formato = formato;
        }
    }
}