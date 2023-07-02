using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace MPSM_Z2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int id;
        private void Category(object sender, RoutedEventArgs e)
        {
            Entitie entities = new Entitie();
            List<Clients> agents = entities.Clients.ToList();
            List<Admins> agents2 = entities.Admins.ToList();
            foreach (var item in agents)
            {
                if (Password.Password == item.Password && Login.Text == item.Login)
                {
                    CategoryWindow window = new CategoryWindow(item.ID);
                    id = item.ID;
                    CabinetWindow window2 = new CabinetWindow(item.ID);
                    CabinetRedactWindow window3 = new CabinetRedactWindow(item.ID);
                    window.Show();
                    this.Close();
                    Login.Text = item.Login;
                    Trace.Listeners.Add(new TextWriterTraceListener(File.Open("svodkalogin.txt", FileMode.OpenOrCreate)));
                    Trace.AutoFlush = true;
                    MessageBox.Show("Добро пожаловать " + item.Login + "!");
                    Trace.WriteLine("-------------------------------");
                    Trace.WriteLine(Login.Text);
                    Trace.WriteLine(Password.Password);
                    Trace.WriteLine("-------------------------------");
                    return;
                }
            }
            foreach (var item2 in agents2)
            {
                if (Password.Password == item2.Password && Login.Text == item2.Login)
                {
                    CategoryAdminWindow window = new CategoryAdminWindow(id);
                    window.Show();
                    this.Close();
                    Trace.Listeners.Add(new TextWriterTraceListener(File.Open("svodkalogin.txt", FileMode.OpenOrCreate)));
                    Trace.AutoFlush = true;
                    Trace.WriteLine("-------------------------------");
                    Trace.WriteLine(Login.Text);
                    Trace.WriteLine(Password.Password);
                    Trace.WriteLine("-------------------------------");
                    return;
                }
            }
            foreach (var item in agents)
            {
                foreach (var item2 in agents2)
                {
                    if (Password.Password != item2.Password && Login.Text != item2.Login || Password.Password != item.Password && Login.Text != item.Login)
                    {
                        MessageBox.Show("Такого пользователя не существует");
                        return;
                    }
                }
            }
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterWindow window = new RegisterWindow(id);
            window.Show();
            this.Close();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

    }
}
