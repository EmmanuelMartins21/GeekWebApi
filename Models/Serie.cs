using System.ComponentModel.DataAnnotations;

namespace GeekWebApi.Models
{
    public class Serie
    {
        public Serie(string nome, string empresa, string genero, DateTime dataLancamento, float temporadas)
        {
            Nome = nome;
            Empresa = empresa;
            Genero = genero;
            DataLancamento = dataLancamento;
            Temporadas = temporadas;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string Genero { get; set; }
        public DateTime DataLancamento { get; set; }
        public float Temporadas { get; set; }
    }
}
