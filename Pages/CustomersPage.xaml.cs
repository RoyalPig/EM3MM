using Microsoft.EntityFrameworkCore;
using EX3MM.Data;
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

namespace EX3MM.Pages
{
    /// <summary>
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        NorthwindContext context = new NorthwindContext();
        CollectionViewSource customerViewSource = new CollectionViewSource();

        public CustomersPage()
        {
            InitializeComponent();

            //Tie the markup viewsource object to the code viewsource object
            customerViewSource = (CollectionViewSource)FindResource(nameof(customerViewSource));

            //Use the dbcontext to tell EF to load data from the db
            context.Customers.Load();

            //Set the viewsource data source to use the customer data collection
            customerViewSource.Source = context.Customers.Local.ToObservableCollection();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
