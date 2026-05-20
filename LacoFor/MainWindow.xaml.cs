using System.Windows;
using System.Windows.Input;

namespace LacoFor;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public decimal saldoInicial = 1234.00M;
    private string[] emoticons = { "🐯", "🍊", "💎", "💰", "🍒", "🔔" };
    private const decimal custoSorteio = 9.99M;

    public MainWindow()
    {
        InitializeComponent();
        tbSaldo.Text = $"R$ {saldoInicial}";
        tbCusto.Text = $"R$ {custoSorteio}";
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(tbQuantidade.Text, out var quantidadeSorteios))
        {
            MessageBox.Show("Coloque apenas valores númericos!");
            return;
        }

        // Desabilita o botão
        btnSorteio.IsEnabled = false;

        if (quantidadeSorteios < 1) quantidadeSorteios = 1;
        var sorteador = new Random();
        // contador++ ; contador += 1; contador = contador + 1
        for (var contador = 0; contador < quantidadeSorteios; contador++)
            if (saldoInicial >= custoSorteio)
            {
                saldoInicial -= custoSorteio;
                tbSaldo.Text = $"R$ {saldoInicial}";

                var numeroSorteado = sorteador.Next(40000001);

                if (numeroSorteado == 3)
                {
                    tbSlot1.Text = emoticons[0];
                    tbSlot2.Text = emoticons[0];
                    tbSlot3.Text = emoticons[0];
                    saldoInicial += custoSorteio * 2;
                    tbSaldo.Text = $"R$ {saldoInicial}";
                }
                else
                {
                    int slot1, slot2, slot3;
                    do
                    {
                        slot1 = sorteador.Next(emoticons.Length);
                        slot2 = sorteador.Next(emoticons.Length);
                        slot3 = sorteador.Next(emoticons.Length);
                    } while (slot1 == slot2 && slot2 == slot3);

                    tbSlot1.Text = emoticons[slot1];
                    tbSlot2.Text = emoticons[slot2];
                    tbSlot3.Text = emoticons[slot3];
                }

                await Task.Delay(1000);
            }
            else
            {
                MessageBox.Show("Você não tem saldo suficiente para realizar o sorteio!");
                break;
            }

        // Habilita o botão
        btnSorteio.IsEnabled = true;
    }

    private void TbQuantidade_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (!int.TryParse(tbQuantidade.Text, out var quantidadeSorteio) || quantidadeSorteio < 1)
        {
            quantidadeSorteio = 1;
        }
        
        // Calculo do custo total
        decimal custoTotal = quantidadeSorteio * custoSorteio;
        
        // Inserir o custoTotal na interface
        tbCusto.Text = $"R$ {custoTotal}";
    }
}