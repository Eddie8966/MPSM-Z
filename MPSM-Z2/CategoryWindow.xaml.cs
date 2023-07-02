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
using System.Xml.Schema;

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
        float sum1 = 0;
        float sum2 = 0;
        float sum3 = 0;
        int id;
        public CategoryWindow(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void Brus(object sender, RoutedEventArgs e)
        {
            Entitie entity = new Entitie();
            List<Items> item = entity.Items.ToList();
            
            Bag bag = new Bag();
            bag.ID_Item = 1;
            k1++;
            foreach(var it in item)
            {
                if(it.ID == bag.ID_Item)
                sum1 = (float)(sum1 + it.Price);
            }
            entity.Bag.Add(bag);
            entity.SaveChanges();
            entity.Dispose();
        }
        private void Gran(object sender, RoutedEventArgs e)
        {
            Entitie entity = new Entitie();
            List<Items> item = entity.Items.ToList();

            Bag bag = new Bag();
            bag.ID_Item = 2;
            k2++;
            foreach (var it in item)
            {
                if (it.ID == bag.ID_Item)
                    sum2 = (float)(sum2 + it.Price);
            }
            entity.Bag.Add(bag);
            entity.SaveChanges();
            entity.Dispose();
        }
        private void Shield(object sender, RoutedEventArgs e)
        {
            Entitie entity = new Entitie();
            List<Items> item = entity.Items.ToList();

            Bag bag = new Bag();
            bag.ID_Item = 3;
            k3++;
            foreach (var it in item)
            {
                if (it.ID == bag.ID_Item)
                    sum3 = (float)(sum3 + it.Price);
            }
            entity.Bag.Add(bag);
            entity.SaveChanges();
            entity.Dispose();
        }
        private void Cabinet(object sender, RoutedEventArgs e)
        {
            Entitie entity = new Entitie();
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
            Entitie entity = new Entitie();
            OrderingWindow window = new OrderingWindow(id,k1,k2,k3,sum1,sum2,sum3);
            List<Items> item = entity.Items.ToList();
            foreach(var it in item)
            {
                if (it.ID == 1)
                {
                    window.Item1.Text = it.Name;
                    window.Count1.Text = Convert.ToString(k1);
                    window.Price1.Text = Convert.ToString(sum1);
                }
                if (it.ID == 2)
                {
                    window.Item2.Text = it.Name;
                    window.Count2.Text = Convert.ToString(k2);
                    window.Price2.Text = Convert.ToString(sum2);
                }
                if (it.ID == 3)
                {
                    window.Item3.Text = it.Name;
                    window.Count3.Text = Convert.ToString(k3);
                    window.Price3.Text = Convert.ToString(sum3);
                }
            }
            window.Show();
            this.Close();
        }
    }
}
