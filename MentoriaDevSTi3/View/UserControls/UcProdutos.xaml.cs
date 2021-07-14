using Mentoria_STi3.ViewModel;
using MentoriaDevSTi3.Business;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Mentoria_STi3.View.UserControls
{
    /// <summary>
    /// Interaction logic for UCProdutos.xaml
    /// </summary>
    public partial class UCProdutos : UserControl
    {
        private UcProdutoViewModel UcProdutoVM = new UcProdutoViewModel();

        public UCProdutos()
        {
            InitializeComponent();

            DataContext = UcProdutoVM;

            CarregarRegistros();
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarProduto()) return;

            if (UcProdutoVM.Alteracao)
            {
                AlterarProduto();
            }
            else
            {
                AdicionarProduto();
            }

            LimparCampos();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var produto = (sender as Button).Tag as ProdutoViewModel;

            PreencherCampos(produto);

        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            var produto = (sender as Button).Tag as ProdutoViewModel;

            RemoverProduto(produto.Id);
        }

        private void TxtValor_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PreencherCampos(ProdutoViewModel produto)
        {
            UcProdutoVM.Id = produto.Id;
            UcProdutoVM.Nome = produto.Nome;
            UcProdutoVM.Valor = produto.Valor;

            UcProdutoVM.Alteracao = true;
        }

        private void CarregarRegistros()
        {
            UcProdutoVM.ProdutosAdicionados = new ObservableCollection<ProdutoViewModel>(new ProdutoBusiness().Listar());
        }

        private void AdicionarProduto()
        {
            var novoProduto = new ProdutoViewModel
            {
                Nome = UcProdutoVM.Nome,
                Valor = UcProdutoVM.Valor
            };
            new ProdutoBusiness().Adicionar(novoProduto);

            CarregarRegistros();

        }

        private void AlterarProduto()
        {
            var produtoAlteracao = new ProdutoViewModel
            {
                Id = UcProdutoVM.Id,
                Nome = UcProdutoVM.Nome,
                Valor = UcProdutoVM.Valor
            };
            new ProdutoBusiness().Alterar(produtoAlteracao);

            CarregarRegistros();
        }

        private void RemoverProduto(long id)
        {
            var resultado = MessageBox.Show("Deseja realmente remover o produto ?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if(resultado == MessageBoxResult.Yes)
            {
                new ProdutoBusiness().Remover(id);
                CarregarRegistros();
                LimparCampos();

            }
        }

        private void LimparCampos()
        {
            UcProdutoVM.Id = 0;
            UcProdutoVM.Nome = "";
            UcProdutoVM.Valor = 0;

            UcProdutoVM.Alteracao = false;
        }

        private bool ValidarProduto()
        {
            if (string.IsNullOrEmpty(UcProdutoVM.Nome))
            {
                MessageBox.Show("O Campo Nome é obrigatório!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }




    }


}
