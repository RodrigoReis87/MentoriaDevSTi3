using Mentoria_STi3.ViewModel;
using MentoriaDevSTi3.Business;
using MentoriaDevSTi3.ViewModel;
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

        }

        private void BtnFinalizarPedido_Click(object sender, RoutedEventArgs e)
        {
            FinalizarPedido();   
            InicializarOperacao();
        }

        private void InicializarOperacao()
        {
            DataContext = UcPedidoVM;

            UcPedidoVM.ListaClientes = new ObservableCollection<ClienteViewModel>(new ClienteBusiness().Listar());

            UcPedidoVM.ListaProdutos = new ObservableCollection<ProdutoViewModel>(new ProdutoBusiness().Listar());
            
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
                ValorTotalItem = UcPedidoVM.Quantidade * UcPedidoVM.ValorUnit,
                ProdutoId = produtoSelecionado.Id
            };

            UcPedidoVM.ItensAdicionados.Add(itemVM);
            UcPedidoVM.ValorTotalPedido = UcPedidoVM.ItensAdicionados.Sum(i => i.ValorTotalItem);

            LimparCamposProduto();
        }

        private void LimparCamposProduto()
        {
            UcPedidoVM.ValorUnit = 0;
            CmbProduto.SelectedItem = null;
            UcPedidoVM.Quantidade = 1;

        }

        private void LimparTodosCampos()
        {
            UcPedidoVM.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();
            UcPedidoVM.ValorTotalPedido = 0;
            CmbCliente.SelectedItem = null;
            CmbFormaPagto.SelectedItem = null;

            LimparCamposProduto();
        }

        private void FinalizarPedido()
        {
            var clienteSelecionado = CmbCliente.SelectedItem as ClienteViewModel;
            var FormaPagamentoSelecionada = CmbFormaPagto.SelectedItem as string;
            var pedidoViewModel = new PedidoViewModel
            {
                ClienteId = clienteSelecionado.Id,
                FormaPagamento = FormaPagamentoSelecionada,
                Valor = UcPedidoVM.ValorTotalPedido,
                ItensPedido = UcPedidoVM.ItensAdicionados.Select(s => new ItemPedidoViewModel
                {
                    ProdutoId = s.ProdutoId,
                    Quantidade = s.Quantidade,
                    Valor = s.ValorTotalItem
                }).ToList()
            };

            new PedidoBusiness().Adicionar(pedidoViewModel);

            MessageBox.Show("Pedido finalizado! Valor total R$" + UcPedidoVM.ValorTotalPedido,
                "Pedido Finalizado", MessageBoxButton.OK, MessageBoxImage.Information);
            UcPedidoVM.ValorTotalPedido = 0;

            LimparTodosCampos();
        }

    }
}
