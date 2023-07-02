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
using System.Windows.Shapes;

namespace MPSM_Z2
{
    /// <summary>
    /// Логика взаимодействия для CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        int k1 = 0;
        int k2 = 0;
        int k3 = 0;
        int id;
        public CategoryWindow(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void Brus(object sender, RoutedEventArgs e)
        {
            Entities entity = new Entities();
            Bag bag = new Bag();
            bag.ID_Item = 1;
            k1++;
            entity.Bag.Add(bag);
            entity.SaveChanges();
            entity.Dispose();
        }
        private void Gran(object sender, RoutedEventArgs e)
        {
            Entities entity = new Entities();
            Bag bag = new Bag();
            bag.ID_Item = 2;
            k2++;
            entity.Bag.Add(bag);
            entity.SaveChanges();
            entity.Dispose();
        }
        private void Shield(object sender, RoutedEventArgs e)
        {
            Entities entity = new Entities();
            Bag bag = new Bag();
            bag.ID_Item = 3;
            k3++;
            entity.Bag.Add(bag);
            entity.SaveChanges();
            entity.Dispose();
        }
        private void Cabinet(object sender, RoutedEventArgs e)
        {
            Entities entity = new Entities();
            List<Clients> registr = entity.Clients.ToList();
            CabinetWindow window = new CabinetWindow(id);
            foreach (var item in registr)
            {
                if (id == item.ID)
                {
                    window.FIO.Text = item.FIO;
                    window.Phone.Text = item.Phone;
                    window.Organization.Text = item.Organization;
                    window.Login.Text = item.Login;
                    window.Password.Text = item.Password;
                    window.Adress.Text = item.Adress;
                }
            }
            window.Show();
            this.Close();
        }
        private void Order(object sender, RoutedEventArgs e)
        {
            OrderingWindow window = new OrderingWindow(id);
            window.Show();
            this.Close();
        }
    }
}
