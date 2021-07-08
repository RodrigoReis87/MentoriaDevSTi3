using Mentoria_STi3.ViewModel;
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

            UcProdutoVM.ProdutosAdicionados = new ObservableCollection<ProdutoViewModel>();
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

        }

        private void TxtValor_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PreencherCampos(ProdutoViewModel produto)
        {
            UcProdutoVM.Nome = produto.Nome;
            UcProdutoVM.Valor = produto.Valor;

            UcProdutoVM.Alteracao = true;
        }

        private void AdicionarProduto()
        {
            var novoProduto = new ProdutoViewModel
            {
                Nome = UcProdutoVM.Nome,
                Valor = UcProdutoVM.Valor
            };
            UcProdutoVM.ProdutosAdicionados.Add(novoProduto);

        }

        private void AlterarProduto()
        {
            //será desenvolvido na aula de banco de dados.
        }

        private void LimparCampos()
        {
            UcProdutoVM.Nome = "";
            UcProdutoVM.Valor = 0;

            UcProdutoVM.Alteracao = false;
        }

        private void RemoverProdutos()
        {

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
