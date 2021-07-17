using System;

namespace Mentoria_STi3.ViewModel
{
    public class ClienteViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
    }
}
