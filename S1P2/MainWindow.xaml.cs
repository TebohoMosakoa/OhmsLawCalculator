using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S1P2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate int OhmsLawDelegate(int p1, int p2);

        public int CalVoltage(int current, int resistance) { return current * resistance; }
        public int CalResistance(int voltage, int current) { return voltage / current; }
        public int CalCurrent(int voltage, int resistance) { return voltage / resistance; }
        OhmsLawDelegate ohmsLaw = null;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void cboCalcType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cboCalcType.SelectedIndex;

            switch (index)
            {
                case 0:
                    lblFirstValue.Text = "Voltage";
                    lblSecondValue.Text = "Resistance";
                    ohmsLaw = CalCurrent;
                    break;
                case 1:
                    lblFirstValue.Text = "Voltage";
                    lblSecondValue.Text = "current";
                    ohmsLaw = CalResistance;
                    break;
                case 2:
                    lblFirstValue.Text = "current";
                    lblSecondValue.Text = "Resistance";
                    ohmsLaw = CalVoltage;
                    break;
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            switch (cboCalcType.SelectedIndex)
            {
                case 0:
                    lblResult.Text = "The calculated Current is:";
                    ohmsLaw = CalCurrent;
                    break;
                case 1:
                    lblResult.Text = "The calculater Resistance is:";
                    ohmsLaw = CalResistance;
                    break;
                case 2:
                    lblResult.Text = "The calculated Voltage is:";
                    ohmsLaw = CalVoltage;
                    break;
            }
            int parameter1 = Convert.ToInt32(txtFirstValue.Text);
            int parameter2 = Convert.ToInt32(txtSecondValue.Text);
            txtResult.Text = (ohmsLaw(parameter1, parameter2)).ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cboCalcType.SelectedIndex = 0;
            lblResult.Text = "Result";
            lblFirstValue.Text = "Voltage";
            lblSecondValue.Text = "Resistance";
            txtFirstValue.Text = String.Empty;
            txtSecondValue.Text = String.Empty;
            txtResult.Text = String.Empty;
        }
    }
}
