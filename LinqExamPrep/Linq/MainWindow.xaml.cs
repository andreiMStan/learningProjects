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

namespace Linq
{
 /// <summary>
 /// Interaction logic for MainWindow.xaml
 /// </summary>
 public partial class MainWindow : Window
 {
  public MainWindow()
  {
   InitializeComponent();

   // Sample sales data
   List<decimal> salesTotals = new List<decimal> { 1500.00m, 2500.75m, 3200.00m, 1800.00m, 4000.50m };

   // Query to filter sales over $2000
   var salesList = from sales in salesTotals
                   where sales > 150
                   select sales;

   // Prepare the display string
   string salesDisplay = "Sales Over $2000:\n";
   foreach (var sales in salesList)
   {
    salesDisplay += sales.ToString("c") + "\n";
   }

   // Display the sales in the TextBlock
   SalesTextBlock.Text = salesDisplay;
  }
 }
}