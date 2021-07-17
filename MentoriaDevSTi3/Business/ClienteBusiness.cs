using Mentoria_STi3.ViewModel;
using MentoriaDevSTi3.data.Context;
using MentoriaDevSTi3.data.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MentoriaDevSTi3.Business
{
    public class ClienteBusiness
    {
        private readonly MentoriaDevSTi3Context _context;

        public ClienteBusiness()
        {
            _context = new MentoriaDevSTi3Context();
        }

        public void Adicionar(ClienteViewModel clienteViewModel)
        {
            _context.Clientes.Add(new Cliente
            {
                Nome = clienteViewModel.Nome,
                DataNascimento = clienteViewModel.DataNascimento,
                Cep = clienteViewModel.Cep,
                Endereco = clienteViewModel.Endereco,
                Cidade = clienteViewModel.Cidade
            });

            _context.SaveChanges();
        }

        public void Alterar(ClienteViewModel clienteViewModel)
        {
            var cliente = _context.Clientes.First(x => x.Id == clienteViewModel.Id);

            cliente.Nome = clienteViewModel.Nome;
            cliente.DataNascimento = clienteViewModel.DataNascimento;
            cliente.Cep = clienteViewModel.Cep;
            cliente.Endereco = clienteViewModel.Endereco;
            cliente.Cidade = clienteViewModel.Cidade;

            _context.SaveChanges();
        }

        public void Remover(long id)
        {
            var cliente = _context.Clientes.First(x => x.Id == id);

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public List<ClienteViewModel> Listar()
        {
            return _context.Clientes.AsNoTracking()
                .Select(s => new ClienteViewModel
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    DataNascimento = s.DataNascimento,
                    Endereco = s.Endereco,
                    Cidade = s.Cidade,
                    Cep = s.Cep
                }).ToList()
                .OrderBy(x => x.Nome).ToList();
        }

    }
}
