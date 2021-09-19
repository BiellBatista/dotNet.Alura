using System;

namespace _10_04_XX_Geracao_codigo.Antes
{
    [Serializable]
    [FormatoResumido02("{0}  {1}  {2}  {3}")]
    [FormatoDetalhado02("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}")]
    public class Venda02
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
    internal class FormatoResumido02Attribute : Attribute
    {
        public string Formato { get; }

        public FormatoResumido02Attribute(string formato)
        {
            Formato = formato;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class FormatoDetalhado02Attribute : Attribute
    {
        public string Formato { get; }

        public FormatoDetalhado02Attribute(string formato)
        {
            Formato = formato;
        }
    }
}