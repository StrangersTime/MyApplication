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

namespace OlimpiadaForYou
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser()
        {
            InitializeComponent();

            tb_Surname.Text = App._Olimp_Users.Surname;
            tb_Name.Text = App._Olimp_Users.Name;
            tb_Patronymic.Text = App._Olimp_Users.Patronymic;

            tb_Login.Text = App._Olimp_Users.Login;
            tb_Password.Text = App._Olimp_Users.Password;
            dp_Birthday.Text = App._Olimp_Users.DateOfBirth.ToString();
        }

        private void ButEdit_Click(object sender, RoutedEventArgs e)
        {
            var UpdateUser = App.Context.Olimp_Users.Find(App._Olimp_Users.ID);
            if (UpdateUser != null)
            {
                UpdateUser.Surname = tb_Surname.Text;
                UpdateUser.Name = tb_Name.Text;
                UpdateUser.Patronymic = tb_Patronymic.Text;

                UpdateUser.Login = tb_Login.Text;
                UpdateUser.Password = tb_Password.Text;
                UpdateUser.DateOfBirth = (DateTime)dp_Birthday.SelectedDate;

                App.Context.SaveChanges();

                MessageBox.Show("Не забудьте сообщить об изменениях своим учителям!");

                UserWindow userWindow = new UserWindow();
                userWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButReturn_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
            this.Close();
        }

        private void tb_Surname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\d"))
            {
                e.Handled = true;
            }
        }

        private void tb_Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\d"))
            {
                e.Handled = true;
            }
        }

        private void tb_Patronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\d"))
            {
                e.Handled = true;
            }
        }
    }
}
