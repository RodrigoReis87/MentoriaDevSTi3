using System;
using System.Collections.Generic;
using System.Text;

namespace MentoriaDevSTi3.ViewModel
{
    public class EnderecoViewModel
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public bool Erro { get; set; }
    }
}
