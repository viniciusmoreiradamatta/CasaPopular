using System;
using System.Collections.Generic;

namespace CasaPopular.Application.ViewModels
{
    public class CadastroPessoaViewModel
    {
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public decimal Renda { get; set; }
        public DateTime DataNascimento { get; set; }
    }

    public class CadastroFamiliaViewModel
    {
        public int Status { get; set; }
        public List<CadastroPessoaViewModel> Pessoas { get; set; }
    }
}