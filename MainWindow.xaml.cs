using Ekz_codeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Ekz_codeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ItemContext db = new ItemContext();
            var events = from d in db.Items select d;
            existingItemsGrid.ItemsSource = events.ToList();

            new Window1().Show();
          
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            ItemContext db = new ItemContext();
            Item events = new Item()
            {
                Name = Name.Text,
                Price = Convert.ToInt32(Price.Text),
                Room = Room.Text,
                Date = DateTime.Now,
                ProducYear = Convert.ToInt32(ProducYear.Text)
            };
            db.Items.Add(events);
            db.SaveChanges();
            existingItemsGrid.ItemsSource = (from d in db.Items select d).ToList();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            ItemContext db = new ItemContext();
            Item cus = (Item)existingItemsGrid.SelectedItem;
            db.Entry(cus).State = EntityState.Deleted;
            db.SaveChanges();
            existingItemsGrid.ItemsSource = (from d in db.Items select d).ToList();
        }


       
    }
}
