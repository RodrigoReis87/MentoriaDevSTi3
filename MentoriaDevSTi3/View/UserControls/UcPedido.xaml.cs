using Mentoria_STi3.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Mentoria_STi3.View.UserControls
{
    /// <summary>
    /// Interaction logic for UcPedido.xaml
    /// </summary>
    public partial class UcPedido : UserControl
    {
        private UcPedidoViewModel UcPedidoVM = new UcPedidoViewModel();

        public UcPedido()
        {
            InitializeComponent();

            InicializarOperacao();
        }

        private void CmbProduto_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox cmb && cmb.SelectedItem is ProdutoViewModel produto)
            {
                UcPedidoVM.ValorUnit = produto.Valor;
            }
        }

        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            AdicionarItem();

            LimparCampos();
        }

        private void BtnFinalizarPedido_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pedido finalizado! Valor total R$" + UcPedidoVM.ValorTotalPedido,
                "Pedido Finalizado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            UcPedidoVM.ValorTotalPedido = 0;
            InicializarOperacao();
        }

        private void InicializarOperacao()
        {
            DataContext = UcPedidoVM;

            UcPedidoVM.ListaClientes = new ObservableCollection<ClienteViewModel>
            {
                new ClienteViewModel{Nome = "Cliente1"},
                new ClienteViewModel { Nome = "Cliente2"}
            };

            UcPedidoVM.ListaProdutos = new ObservableCollection<ProdutoViewModel>
            {
                new ProdutoViewModel{Nome = "Produto 1", Valor = 10},
                new ProdutoViewModel{Nome = "Produto 2", Valor = 20}
            };

            UcPedidoVM.ListaPagamentos = new ObservableCollection<string>
            {
                "Dinheiro",
                "Boleto",
                "Cartão de Crédito",
                "Cartão de Débito",
                "PIX",
            };

            UcPedidoVM.Quantidade = 1;

            UcPedidoVM.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();
        }

        private void AdicionarItem()
        {
            var produtoSelecionado = CmbProduto.SelectedItem as ProdutoViewModel;

            var itemVM = new UcPedidoItemViewModel
            {
                Nome = produtoSelecionado.Nome,
                Quantidade = UcPedidoVM.Quantidade,
                ValorUnit = UcPedidoVM.ValorUnit,
                ValorTotalItem = UcPedidoVM.Quantidade * UcPedidoVM.ValorUnit
            };

            UcPedidoVM.ItensAdicionados.Add(itemVM);
            UcPedidoVM.ValorTotalPedido = UcPedidoVM.ItensAdicionados.Sum(i => i.ValorTotalItem);
        }

        private void LimparCampos()
        {
            UcPedidoVM.ValorUnit = 0;
            CmbCliente.Text = "";
            CmbFormaPagto.Text = "";
            CmbProduto.Text = "";
            UcPedidoVM.Quantidade = 1;

        }

    }
}
