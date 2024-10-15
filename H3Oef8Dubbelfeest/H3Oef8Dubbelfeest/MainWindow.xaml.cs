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

namespace H3Oef8Dubbelfeest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            amountOfPersonsTextBox.Clear();
            chanceTextBox.Clear();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            //De gehele getallen staan met een '.00' omdat anders de berekening niet goed werkt: het systeem leest het als een integer, ook al staat voor de variabele 'double'
            
            int amountOfPeople;
            double differentBdayChance = 1.00;
            string inputAmountOfPeople = amountOfPersonsTextBox.Text;

            bool isInputValid = int.TryParse(inputAmountOfPeople, out amountOfPeople);

            if (isInputValid && amountOfPeople > 0)
            {
                for ( int amountOfBdays = 1; amountOfBdays <= amountOfPeople; amountOfBdays++)
                {
                    double bday = (365.00 - ( amountOfBdays - 1.00)) / 365.00; //De '-1.00' is omdat anders is de kans op een sameBday niet 0% als het aantal personen 1 is

                    differentBdayChance *= bday;
                    double sameBdayChance = 1.00 - differentBdayChance;

                    chanceTextBox.Text = $"De kans op gelijke verjaardagen is {sameBdayChance.ToString("#0.##%")}";
                }
            }
            else if (amountOfPeople <= 0)
            {
                chanceTextBox.Text = "Aantal personen kan niet 0 of negatief zijn!";
            }
            else
            {
                chanceTextBox.Text = "Geef een geldig geheel getal in!";
            }
        }
    }
}