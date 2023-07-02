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
    /// Логика взаимодействия для CategoryAdminWindow.xaml
    /// </summary>
    public partial class CategoryAdminWindow : Window
    {
        public CategoryAdminWindow()
        {
            InitializeComponent();
        }
        private void Cabinet(object sender, RoutedEventArgs e)
        {
            CabinetWindow window = new CabinetWindow();
            window.Show();
            this.Close();
        }
        private void CurrentOrders(object sender, RoutedEventArgs e)
        {
            CurrentOrdersAdminWindow window = new CurrentOrdersAdminWindow();
            window.Show();

        }
    }
}
