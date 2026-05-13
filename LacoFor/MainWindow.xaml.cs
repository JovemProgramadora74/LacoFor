using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LacoFor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {
        var quantidadeTexto = tbQuantidade.Text;
        var quantidadeSorteios = Convert.ToInt32(quantidadeTexto);
        //var quantidadeSorteios = Convert.ToInt32(tbQuantidade.Text);

        if (quantidadeSorteios < 1)
        {
            quantidadeSorteios = 1;
        }
        
        var sorteador = new Random();
        // contador++ ; contador += 1; contador = contador + 1
        for (int contador = 0; contador < quantidadeSorteios; contador++)
        {
            tbResultado.Text = sorteador.Next(0, 40000000).ToString();
            await Task.Delay(1000);
        }
        
    }
}