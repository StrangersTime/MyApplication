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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OlimpiadaForYou
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lab_Registration_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void but_Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = App.Context.Olimp_Users.Where(p => p.Login == tb_Login.Text && p.Password == pb_Password.Password).FirstOrDefault();
                if (currentUser != null)
                {
                    App._Olimp_Users = currentUser;

                    if (currentUser.ID_Role == 1)
                    {
                        MessageBox.Show("Добро пожаловать, юное дарование!", "Успешно");
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        this.Close();
                    }
                    else if (currentUser.ID_Role == 2)
                    {
                        MessageBox.Show("Добро пожаловать, коллега", "Успешно");
                        CreatorWindow creatorWindow = new CreatorWindow();
                        creatorWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Мы не можем обнаружить вас, пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Мы не можем обнаружить вас, пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так: {ex.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
