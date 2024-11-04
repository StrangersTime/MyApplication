using OlimpiadaForYou.database;
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

namespace OlimpiadaForYou
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void tb_Return_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void But_Registration_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Surname.Text != "" && tb_Name.Text != "" && tb_Login.Text != "" && tb_Password.Text != "" && dp_DateOfBirth.SelectedDate != null)
            {
                DateTime selectedDate = dp_DateOfBirth.SelectedDate.Value;
                DateTime minAllowedDate = DateTime.Now.AddYears(-7);
                DateTime maxAllowedDate = DateTime.Now.AddYears(-18);

                if (selectedDate > minAllowedDate)
                {
                    MessageBox.Show("Возвращайся, когда ты будешь немного старше, солнце!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (selectedDate < maxAllowedDate)
                {
                    MessageBox.Show("Ты уже слишком взрослый для регистрации!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var existingUser = App.Context.Olimp_Users.FirstOrDefault(u => u.Login == tb_Login.Text);
                if (existingUser != null)
                {
                    MessageBox.Show("Этот логин уже занят, кто-то опередил тебя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newUser = new Olimp_Users
                {
                    Surname = tb_Surname.Text,
                    Name = tb_Name.Text,
                    Patronymic = tb_Patronymic.Text,
                    Login = tb_Login.Text,
                    Password = tb_Password.Text,
                    DateOfBirth = selectedDate,
                    ID_Role = 1
                };
                App.Context.Olimp_Users.Add(newUser);
                App.Context.SaveChanges();
                MessageBox.Show("Теперь вы часть семьи!", "Поздравляем!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполни все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void tb_Surname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void tb_Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void tb_Patronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
