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
using System.Windows.Shapes;

namespace Ekz_codeFirst
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			ItemContext db = new ItemContext();
	
			var entries = from d in db.Entries select d;
			existingEntryGrid.ItemsSource = entries.ToList();
		}


        private void Button_Click_Add2(object sender, RoutedEventArgs e)
        {
            ItemContext db = new ItemContext();
            Entry entries = new Entry()
            {
                Surname = Surname.Text,
                Item = Item.Text,
                StartYear = Convert.ToInt32(StartYear.Text),
                EndYear = Convert.ToInt32(EndYear.Text)
            };
            db.Entries.Add(entries);
            db.SaveChanges();
            existingEntryGrid.ItemsSource = (from d in db.Entries select d).ToList();
        }

        private void Button_Click_Delete2(object sender, RoutedEventArgs e)
        {
            ItemContext db = new ItemContext();
            Entry cus = (Entry)existingEntryGrid.SelectedItem;
            db.Entry(cus).State = EntityState.Deleted;
            db.SaveChanges();
            existingEntryGrid.ItemsSource = (from d in db.Entries select d).ToList();
        }


    }
}
