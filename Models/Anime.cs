using System.ComponentModel.DataAnnotations;

namespace GeekWebApi.Models
{
    public class Anime
    {
        
        public Anime(string nome, string genero, DateTime dataLancamento, int temporadas)
        {
            Nome = nome;
            Genero = genero;
            DataLancamento = dataLancamento;
            Temporadas = temporadas;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Genero { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }
        public int Temporadas { get; set; }


    }
}
