using Mentoria_STi3.View.UserControls;
using System.Windows;
using System.Windows.Controls;

namespace Mentoria_STi3.View
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            InicializarUc(sender);
        }

        private void InicializarUc(object sender)
        {
            if (sender is Button btn)
            {
                switch (btn.Name)
                {
                    case nameof(BtnProdutos):
                        Conteudo.Content = new UCProdutos();
                        break;
                    case nameof(BtnClientes):
                        Conteudo.Content = new UcClientes();
                        break;
                    case nameof(BtnPedido):
                        Conteudo.Content = new UcPedido();
                        break;
                    case nameof(BtnSair):
                        App.Current.MainWindow.Close();
                        break;
                    default:
                        break;

                }
            }
        }

    }
}
