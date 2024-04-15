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

namespace PlanilladesueldosW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Horasdetrabajo.TextChanged += CalcularPago;
            Pagoporhora.TextChanged += CalcularPago;
            AFP.TextChanged += CalcularPago;
            ESSALUD.TextChanged += CalcularPago;
            L.Checked += CalcularPago;
            M.Checked += CalcularPago;
            Mi.Checked += CalcularPago;
            J.Checked += CalcularPago;
            V.Checked += CalcularPago;
            S.Checked += CalcularPago;
            D.Checked += CalcularPago;
        }
        private void CalcularPago(object sender, EventArgs e)
        {
            // Obtener horas de trabajo y pago por hora
            if (!int.TryParse(Horasdetrabajo.Text, out int horasTrabajo) || !double.TryParse(Pagoporhora.Text, out double pagoHora))
                return;

            // Calcular el pago por semana
            double pagoSemana = 0;
            if (L.IsChecked == true) pagoSemana += horasTrabajo * pagoHora;
            if (M.IsChecked == true) pagoSemana += horasTrabajo * pagoHora;
            if (Mi.IsChecked == true) pagoSemana += horasTrabajo * pagoHora;
            if (J.IsChecked == true) pagoSemana += horasTrabajo * pagoHora;
            if (V.IsChecked == true) pagoSemana += horasTrabajo * pagoHora;
            if (S.IsChecked == true) pagoSemana += horasTrabajo * pagoHora;
            if (D.IsChecked == true) pagoSemana += horasTrabajo * pagoHora;

            // Mostrar el pago semanal
            Pagoporsemana.Text = pagoSemana.ToString("C"); // Formato de moneda

            // Calcular el pago por mes (aproximadamente 4 semanas)
            double pagoMes = pagoSemana * 4;

            // Mostrar el pago mensual
            Pagopormes.Text = pagoMes.ToString("C"); // Formato de moneda

            // Obtener descuentos de AFP y Essalud
            if (!double.TryParse(AFP.Text, out double descuentoAFP) || !double.TryParse(ESSALUD.Text, out double descuentoESSALUD))
                return;

            // Calcular el monto total con descuentos incluidos
            double totalPagar = pagoMes - descuentoAFP - descuentoESSALUD;

            // Mostrar el total a pagar
            Totalapagar.Text = totalPagar.ToString("C"); // Formato de moneda
        }

        private void Horasdetrabajo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}