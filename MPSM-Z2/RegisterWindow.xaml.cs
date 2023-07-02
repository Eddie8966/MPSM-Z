using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        int id;
        public RegisterWindow(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void Authorization(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Category(object sender, RoutedEventArgs e)
        {
            Entitie entity = new Entitie();
            Clients reg = new Clients();
            List<Clients> registr = entity.Clients.ToList();
            Regex fio = new Regex("^[А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+");
            bool fl = fio.IsMatch(FIO.Text);
            Regex login = new Regex("^[A-Z 0-9 a-z].+");
            bool fg = login.IsMatch(Login.Text);
            Regex password = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9 a-z A-Z]{6,}$");
            bool rg = password.IsMatch(Password.Password);
            Regex phone = new Regex(@"^\+79|89[0-9]{9}$");
            bool ph = phone.IsMatch(Phone.Text);
            Regex hobby = new Regex(@"^[А-Я]{1}[а-я]{6,}$");
            bool hb = hobby.IsMatch(Organization.Text);
            bool pr = false;
            if(Password.Password == ResetPassword.Password)
            {
                pr = true;
            }
                foreach (var item in registr)
                {
                    if (item.Login == Login.Text || item.Phone == Phone.Text)
                    {
                        MessageBox.Show("Пользователь с такими данными уже зарегестрирован");
                        return;
                    }
                }
            if (hb == false || fl == false || fg == false || rg == false || ph == false || pr == false)
            {
                MessageBox.Show("Не все данные введены верно");
            }
            if (Password.Password == Login.Text)
            {
                MessageBox.Show("Пароль и логин не должны совпадать!");
                return;
            }
            if (rg == false)
            {
                MessageBox.Show("В пароле должны содержаться заглавные и строчные буквы Латинского алфавита, а также цифры! Количество символов в пароле должно быть больше 6!");
                return;
            }
            if (hb && fl && fg && rg && ph && pr)
            {
                reg.FIO = FIO.Text;
                reg.Phone = Phone.Text;
                reg.Organization = Organization.Text;
                reg.Adress = Adress.Text;
                reg.Login = Login.Text;
                reg.Password = Password.Password;
                entity.Clients.Add(reg);
                entity.SaveChanges();
                entity.Dispose();
                Trace.WriteLine("-------------------------------");
                Trace.WriteLine(FIO.Text);
                Trace.WriteLine(Phone.Text);
                Trace.WriteLine(Login.Text);
                Trace.WriteLine(Password.Password);
                Trace.WriteLine("-------------------------------");
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
                MessageBox.Show("Вы прошли регистрацию!!!");
                return;
            }
        }
    }
}
