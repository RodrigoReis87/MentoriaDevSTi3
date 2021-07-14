using Mentoria_STi3.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Mentoria_STi3.View.UserControls
{
    /// <summary>
    /// Interaction logic for UcClientes.xaml
    /// </summary>
    public partial class UcClientes : UserControl
    {
        private UcClienteViewModel UcClienteVM = new UcClienteViewModel();
        public UcClientes()
        {
            InitializeComponent();

            DataContext = UcClienteVM;
            UcClienteVM.ClientesAdicionados = new ObservableCollection<ClienteViewModel>();
            UcClienteVM.DataNascimento = new System.DateTime(1980, 1, 1);
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCliente())
                return;
            if (UcClienteVM.Alteracao)
            {
                AlterarCliente();
            }
            else
            {
                AdicionarCliente();
            }
            LimparCampos();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (sender as Button).Tag as ClienteViewModel;
            PreencherCampos(cliente);
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreencherCampos(ClienteViewModel cliente)
        {
            UcClienteVM.Nome = cliente.Nome;
            UcClienteVM.DataNascimento = cliente.DataNascimento;
            UcClienteVM.Cep = cliente.Cep;
            UcClienteVM.Endereco = cliente.Endereco;
            UcClienteVM.Cidade = cliente.Cidade;
            UcClienteVM.Alteracao = true;
        }

        private void AdicionarCliente()
        {

            var novoCliente = new ClienteViewModel
            {
                Nome = UcClienteVM.Nome,
                DataNascimento = UcClienteVM.DataNascimento,
                Cep = UcClienteVM.Cep,
                Endereco = UcClienteVM.Endereco,
                Cidade = UcClienteVM.Cidade
            };
            UcClienteVM.ClientesAdicionados.Add(novoCliente);
        }

        private void AlterarCliente()
        {
            //será desenvolvido na aula de banco de dados
        }

        private void LimparCampos()
        {
            UcClienteVM.Nome = "";
            UcClienteVM.DataNascimento = new System.DateTime(1990, 1, 1);
            UcClienteVM.Cep = 0;
            UcClienteVM.Endereco = "";
            UcClienteVM.Cidade = "";
            UcClienteVM.Alteracao = false;
        }

        private bool ValidarCliente()
        {
            if (string.IsNullOrEmpty(UcClienteVM.Nome))
            {
                MessageBox.Show("O Campo Nome é obrigatório!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
