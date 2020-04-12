using System.ComponentModel.DataAnnotations;

namespace _06_05_XX_CasaDoCodigo.Areas.Catalogo.Models
{
    public class Categoria : BaseModel
    {
        public Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        [Required]
        public string Nome { get; private set; }
    }
}
