using System.ComponentModel.DataAnnotations;

namespace GeekWebApi.Models
{
    public class Serie
    {
        public Serie(int id, string nome, string empresa, DateTime dataLancamento, float temporadas)
        {
            Nome = nome;
            Empresa = empresa;
            DataLancamento = dataLancamento;
            Temporadas = temporadas;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public DateTime DataLancamento { get; set; }
        public float Temporadas { get; set; }
    }
}
