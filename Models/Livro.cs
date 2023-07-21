using System.ComponentModel.DataAnnotations;

namespace GeekWebApi.Models
{
    public class Livro
    {
        public Livro( string nome, string editora, DateTime dataLancamento, int paginas)
        {
            Nome = nome;
            Editora = editora;
            DataLancamento = dataLancamento;
            Paginas = paginas;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Editora { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }
        public int Paginas { get; set; }
    }
}
