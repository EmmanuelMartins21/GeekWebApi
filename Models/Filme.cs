﻿using System.ComponentModel.DataAnnotations;

namespace GeekWebApi.Models
{
    public class Filme
    {
        public Filme(string nome, string empresa, string genero, DateTime dataLancamento, float duracaoMinutos)
        {
            Nome = nome;
            Empresa = empresa;
            Genero = genero;
            DataLancamento = dataLancamento;
            DuracaoMinutos = duracaoMinutos;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string Genero { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }
        public float DuracaoMinutos { get; set; }
    }
}
