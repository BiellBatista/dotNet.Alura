using System;

namespace _10_04_XX_Geracao_codigo.Depois
{
    [Serializable]
    [FormatoResumido("{0}  {1}  {2}  {3}")]
    [FormatoDetalhado("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}")]
    public class Venda
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
    internal class FormatoResumidoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoResumidoAttribute(string formato)
        {
            Formato = formato;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class FormatoDetalhadoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoDetalhadoAttribute(string formato)
        {
            Formato = formato;
        }
    }
}