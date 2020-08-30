namespace _05_04_XX_Service.Cartao
{
    public class CartaoServiceTeste : ICartaoService
    {
        public string ObterCartaoDeCreditoDeDestaque() => "ByteBank Gold Platinum Extra Premium Special.";

        public string ObterCartaoDeDebitoDeDestaque() => "ByteBank Estudante sem taxas de manutenção.";
    }
}
