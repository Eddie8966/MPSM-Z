using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CurrentOrdersAdminWindow.xaml
    /// </summary>
    public partial class CurrentOrdersAdminWindow : Window
    {
        int id;
        public CurrentOrdersAdminWindow(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void Search(object sender, RoutedEventArgs e)
        {
            Entitie entity = new Entitie();
            List<Clients> registr = entity.Clients.ToList();
            List<Orders> orders = entity.Orders.ToList();
            Regex fio = new Regex("^[А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+");
            bool fl = fio.IsMatch(FIO.Text);
            foreach (var item in registr)
            {
                if (FIO.Text == item.FIO)
                {
                    foreach(var item2 in orders)
                    {
                        if (item.ID == item2.ID)
                        {
                            Item.Text = Convert.ToString(item2.ID);
                            Count.Text = Convert.ToString(item2.Count);
                            Price.Text = Convert.ToString(item2.Summa);
                        }
                    }
                }
            }

        }
        private void CategoryAdmin(object sender, RoutedEventArgs e)
        {
            CategoryAdminWindow window = new CategoryAdminWindow(id);
            window.Show();
            this.Close();
        }
    }
}
