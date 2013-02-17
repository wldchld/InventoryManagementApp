using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Material> inventory = new ObservableCollection<Material>();

        private Material selectedItem = null;
        private List<Material> selectedItems = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InventoryManagement_Loaded(object sender, RoutedEventArgs e)
        {
            //When Inventory Management window is loaded 
            //(application is started)
            InventoryItemList.ItemsSource = this.inventory;

            //Some test data
            inventory.Add(new Material("testi1", 1));
            inventory.Add(new Material("asd", 1));
            inventory.Add(new Material("qwe", 1));
            inventory.Add(new Material("rty", 1));
        }

        private void SearchFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchFilter.Text != "Search.." && SearchFilter.Text != String.Empty)
            {
                //Search here
            }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            //Decrease selected item quantity
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            //Increase selected item quantity
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //Go to manage inventory tab and select selected item
        }

        //These functions handle placeholder text "Search.."
        private void SearchFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchFilter.Text == String.Empty)
            {
                SearchFilter.Text = "Search..";
            }
        }
        private void SearchFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchFilter.Text == "Search..")
            {
                SearchFilter.Text = String.Empty;
            }
        }

        //Handle selections. 
        //If one item is selected, it is placed to "selectedItem" variable and "selectedItems" is null.
        //If multiple items are selected, those are placed to "selectedItems" variable as List<Material> and "selectedItem" is null.
        //If all items are deselected both variables are null.
        private void InventoryItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItems.Count > 1)
            {
                this.selectedItem = null;

                var tempList = new List<Material>();
                foreach (var item in (sender as ListView).SelectedItems)
                {
                    tempList.Add(item as Material);
                }
                this.selectedItems = tempList;
            }
            else if ((sender as ListView).SelectedItem != null)
            {
                this.selectedItem = ((sender as ListView).SelectedItem as Material);
                this.selectedItems = null;
            }
            else
            {
                this.selectedItem = null;
                this.selectedItems = null;
            }

            UpdateInventoryItemPanel();
        }

        //This function updates rightside panel of Inventory tab
        private void UpdateInventoryItemPanel()
        {
            if (selectedItem != null)
            {
                this.ItemNameContent.Content = selectedItem.Name;
                this.ItemQuantityContent.Content = selectedItem.Quantity;
                this.ItemUnitContent.Content = selectedItem.TypeOfMeasure;
            }
            else if (selectedItems != null)
            {
                //Something..
            }
            else
            {
                this.ItemNameContent.Content = "";
                this.ItemDescriptionContent.Content = "";
                this.ItemGroupContent.Content = "";
                this.ItemQuantityContent.Content = "0";
                this.ItemUnitContent.Content = "";
                this.ItemPriceContent.Content = "";
                this.ItemPriceUnit.Content = "";
                this.ItemIsInfiniteContent.Content = "";
                this.ItemIsInfiniteContent.Content = "";
                this.ItemBestBeforeContent.Content = "";
            }
        }
    }
}
