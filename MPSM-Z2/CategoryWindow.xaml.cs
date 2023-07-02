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
        public CategoryWindow()
        {
            InitializeComponent();
        }
        private void Category(object sender, RoutedEventArgs e)
        {
            CategoryWindow window = new CategoryWindow();
            window.Show();
            this.Close();
        }
        private void Cabinet(object sender, RoutedEventArgs e)
        {
            CabinetWindow window = new CabinetWindow();
            window.Show();
            this.Close();
        }
        private void Order(object sender, RoutedEventArgs e)
        {
            OrderingWindow window = new OrderingWindow();
            window.Show();
            this.Close();
        }
    }
}
