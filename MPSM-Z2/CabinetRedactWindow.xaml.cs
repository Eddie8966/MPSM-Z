using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для CabinetRedactWindow.xaml
    /// </summary>
    public partial class CabinetRedactWindow : Window
    {
        int id;
        public CabinetRedactWindow(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void Cabinet(object sender, RoutedEventArgs e)
        {
            Entities entity = new Entities();
            List<Clients> user = entity.Clients.ToList();
            Clients client = entity.Clients.Where(a => a.ID == id).First();
            Regex fio = new Regex("^[А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+");
            bool fl = fio.IsMatch(FIO.Text);
            Regex login = new Regex("^[A-Z 0-9 a-z].+");
            bool fg = login.IsMatch(Login.Text);
            Regex password = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9 a-z A-Z]{6,}$");
            bool rg = password.IsMatch(Password.Text);
            Regex phone = new Regex(@"^\+79|89[0-9]{9}$");
            bool ph = phone.IsMatch(Phone.Text);
            Regex hobby = new Regex(@"^[А-Я]{1}[а-я]{6,}$");
            bool hb = hobby.IsMatch(Organization.Text);
            if (hb == false || fl == false || fg == false || rg == false || ph == false)
            {
                MessageBox.Show("Не все данные введены верно");
                return;
            }
            if (rg == false)
            {
                MessageBox.Show("В пароле должны содержаться заглавные и строчные буквы Латинского алфавита, а также цифры! Количество символов в пароле должно быть больше 6!");
                return;
            }
            if (Password.Text == Login.Text)
            {
                MessageBox.Show("Пароль и логин не должны совпадать!");
                return;
            }
            if (hb && fl && fg && rg && ph)
            {
                client.Login = Login.Text;
                client.Password = Password.Text;
                client.FIO = FIO.Text;
                client.Phone = Phone.Text;
                client.Organization = Organization.Text;
                client.Adress = Adress.Text;
                entity.SaveChanges();
                entity.Dispose();
                CabinetWindow cat = new CabinetWindow(id);
                foreach (var item in user)
                {
                    if (id == item.ID)
                    {
                        cat.FIO.Text = item.FIO;
                        cat.Phone.Text = item.Phone;
                        cat.Organization.Text = item.Organization;
                        cat.Login.Text = item.Login;
                        cat.Password.Text = item.Password;
                        cat.Adress.Text = item.Adress;
                    }
                }
                cat.Show();
                this.Close();
                MessageBox.Show("Редактирование данных успешно!");
                return;
            }
        }
    }
}
