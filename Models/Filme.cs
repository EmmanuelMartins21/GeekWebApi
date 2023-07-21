using System.ComponentModel.DataAnnotations;

namespace GeekWebApi.Models
{
    public class Filme
    {
        public Filme( string nome, string empresa, DateTime dataLancamento, float duracaoMinutos)
        {            
            Nome = nome;
            Empresa = empresa;
            DataLancamento = dataLancamento;
            DuracaoMinutos = duracaoMinutos;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }
        public float DuracaoMinutos { get; set; }
    }
}
