using System.Text.RegularExpressions;
using MPSM_Z2;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void AdminFIOInputTest()
        {
            Admins users = new Admins();
            users.FIO = "Иванов Алексей Ибрагимович";
            Regex fio = new Regex("^[А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+");
            Assert.Matches(fio, users.FIO);
        }
        [Fact]
        public void AdminPasswordLoginTest()
        {
            Admins en = new Admins();
            en.Password = "Admin";
            en.Login = "Admins";
            Assert.NotEqual(en.Login, en.Password);
        }
        [Fact]
        public void PhoneStartTest()
        {
            Clients en = new Clients();
            en.Phone = "89503403495";
            Assert.Contains("89", en.Phone);
        }
        [Fact]
        public void PhoneIsNullTest()
        {
            Clients ph = new Clients();
            ph.Phone = null;
            Assert.Null(ph.Phone);
        }
        [Fact]
        public void PasswordInputTest()
        {
            Admins en = new Admins();
            Regex password = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9 a-z A-Z]{6,}$");
            en.Password = "Gogs132";
            Assert.Matches(password, en.Password);
        }
        [Fact]
        public void OrganizationIsNotNullTest()
        {
            Clients en = new Clients();
            en.Organization = "Верхушка";
            Assert.NotNull(en.Organization);
        }
        [Fact]
        public void AdressInputTest()
        {
            Clients en = new Clients();
            Regex Adress = new Regex("^[А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+ [А-Я]{1}[а-я].+");
            en.Adress = "Нижний Новгород";
            Assert.DoesNotMatch(Adress, en.Adress);
        }
    }
}