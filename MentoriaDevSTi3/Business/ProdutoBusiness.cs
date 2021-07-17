using Mentoria_STi3.ViewModel;
using MentoriaDevSTi3.data.Context;
using MentoriaDevSTi3.data.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MentoriaDevSTi3.Business
{
    public class ProdutoBusiness
    {
        private readonly MentoriaDevSTi3Context _context;

        public ProdutoBusiness()
        {
            _context = new MentoriaDevSTi3Context();
        }

        public void Adicionar(ProdutoViewModel produtoViewModel)
        {
            _context.Produtos.Add(new Produto
            {
                Nome = produtoViewModel.Nome,
                Valor = produtoViewModel.Valor
            });

            _context.SaveChanges();
        }

        public void Alterar(ProdutoViewModel produtoViewModel)
        {
            var produto = _context.Produtos.Find(produtoViewModel.Id);

            produto.Nome = produtoViewModel.Nome;
            produto.Valor = produtoViewModel.Valor;

            _context.SaveChanges();
        }

        public void Remover(long id)
        {
            var produto = _context.Produtos.First(x => x.Id == id);

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public List<ProdutoViewModel> Listar()
        {
            return _context.Produtos.AsNoTracking()
                .Select(s => new ProdutoViewModel
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Valor = s.Valor
                }).ToList()
                .OrderBy(x => x.Nome).ToList();
        }
    }
}
