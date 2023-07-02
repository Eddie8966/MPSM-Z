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
    /// Логика взаимодействия для OrderingWindow.xaml
    /// </summary>
    public partial class OrderingWindow : Window
    {
        float sum = 0;
        int k = 0;
        int id;
        int k1 = 0;
        int k2 = 0;
        int k3 = 0;
        float sum1 = 0;
        float sum2 = 0;
        float sum3 = 0;
        public OrderingWindow(int id, int k1, int k2, int k3, float sum1, float sum2, float sum3)
        {
            InitializeComponent();
            this.id = id;
            this.k1 = k1;
            this.k2 = k2;
            this.k3 = k3;
            this.sum1 = sum1;
            this.sum2 = sum2;
            this.sum3 = sum3;
        }
        private void Category(object sender, RoutedEventArgs e)
        {
            Entitie entity = new Entitie();
            CategoryWindow window = new CategoryWindow(id);
            List<Orders> ord = entity.Orders.ToList();
            Orders order = new Orders();
            sum = sum1+sum2+sum3;
            k = k1+k2+k3;
            order.Summa = sum;
            order.Count = k;
            order.ID_Client = id;
            entity.Orders.Add(order);
            entity.SaveChanges();
            entity.Dispose();
            window.Show();
            this.Close();
        }
       
    }
}
