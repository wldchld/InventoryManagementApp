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

namespace InventoryManagement
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Material mat = new Material(materialT.Text, Double.Parse(quantityT.Text));
            shoplist.AddToList(mat);

            tBox.Clear();
            List<Material> content = shoplist.Content;
            for (int i = 0; i < content.Count; i++)
            {
                tBox.Text += content[i] + "\n";
            }
        }

        private static ShoppingList shoplist = new ShoppingList();
    }
}
