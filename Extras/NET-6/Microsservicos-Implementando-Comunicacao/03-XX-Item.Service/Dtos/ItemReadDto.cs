namespace _03_XX_Item.Service.Dtos;

public class ItemReadDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int IdRestaurante { get; set; }
}