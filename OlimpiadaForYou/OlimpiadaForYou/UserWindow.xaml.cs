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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            if (App._Olimp_Users.Patronymic != "")
            {
                tb_FIO.Text = App._Olimp_Users.Surname + " " + App._Olimp_Users.Name + " " + App._Olimp_Users.Patronymic + "!";
            }
            else tb_FIO.Text = App._Olimp_Users.Surname + " " + App._Olimp_Users.Name + "!";

            Olimpiadas();
        }

        private List<Olimp_Olimp> _olimpList;
        private int _currentPage = 0;

        /// Загружает список олимпиад, на которые зарегистрирован текущий пользователь, сортирует их и обновляет интерфейс.
        private void Olimpiadas()
        {
            _olimpList = App.Context.Olimp_Olimp
                .Include("Olimp_Registration")
                .Where(p => p.Olimp_Registration.Any(reg => reg.ID_Olimp == p.ID && reg.ID_User == App._Olimp_Users.ID))
                .ToList();

            _olimpList = _olimpList.OrderBy(p => p.DateOfEvent < DateTime.Now).ThenBy(p => p.DateOfEvent).ToList();

            if (_olimpList != null && _olimpList.Count > 0)
            {
                ShowCurrentItem();
                UpdateButtonVisibility();
            }
            else
            {
                lv_Olimp.Visibility = Visibility.Hidden;
                messageTextBlock.Visibility = Visibility.Visible;
            }
        }

        /// Обновляет видимость кнопок навигации (Назад и Вперед) в зависимости от текущей страницы.
        private void UpdateButtonVisibility()
        {
            But_Back.Visibility = _currentPage > 0 ? Visibility.Visible : Visibility.Hidden;
            But_Next.Visibility = _currentPage < _olimpList.Count - 1 ? Visibility.Visible : Visibility.Hidden;
        }

        /// Отображает текущую олимпиаду на основе индекса текущей страницы.
        private void ShowCurrentItem()
        {
            if (_olimpList != null && _olimpList.Count > 0)
            {
                lv_Olimp.ItemsSource = new List<Olimp_Olimp> { _olimpList[_currentPage] };

                tb_NumberOfPage.Text = $"{_currentPage + 1}";
            }
        }

        /// Обработчик клика по кнопке "Назад". Уменьшает текущую страницу и обновляет отображение.
        private void But_Back_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                ShowCurrentItem();
                UpdateButtonVisibility();
            }
        }

        // Обработчик клика по кнопке "Вперед". Увеличивает текущую страницу и обновляет отображение.
        private void But_Next_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < _olimpList.Count - 1)
            {
                _currentPage++;
                ShowCurrentItem();
                UpdateButtonVisibility();
            }
        }

        /// Обработчик события нажатия мыши на текстовом блоке для перехода к списку олимпиад.
        private void tb_Reg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OlimpListWindow olimpListWindow = new OlimpListWindow();
            olimpListWindow.Show();
            this.Close();
        }

        /// Обработчик клика по кнопке "Выйти". Открывает главное окно приложения.
        private void But_Return_Click(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        /// Обработчик клика по кнопке "Отказ". Удаляет регистрацию пользователя на олимпиаду, обновляет список олимпиад и отображает соответствующее сообщение.
        private void But_Refuse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deleteThis = (sender as Button).DataContext as Olimp_Olimp;
                if (MessageBox.Show("Ты не хочешь участвовать в олимпиаде?", "Ты уверен?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var thisOlimp = App.Context.Olimp_Registration
                        .FirstOrDefault(p => p.ID_User == App._Olimp_Users.ID && p.ID_Olimp == deleteThis.ID);

                    if (thisOlimp != null)
                    {
                        App.Context.Olimp_Registration.Remove(thisOlimp);
                        App.Context.SaveChanges();
                        MessageBox.Show("Ничего страшного, не переживай :)");

                        _olimpList = App.Context.Olimp_Olimp
                            .Include("Olimp_Registration")
                            .Where(p => p.Olimp_Registration.Any(reg => reg.ID_Olimp == p.ID && reg.ID_User == App._Olimp_Users.ID))
                            .ToList();

                        if (_currentPage == _olimpList.Count)
                        {
                            _currentPage--;
                        }
                        Olimpiadas();
                        ShowCurrentItem();
                        UpdateButtonVisibility();
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так или вы не зарегистрированы на эту олимпиаду.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
        /// Обработчик клика по иконке. Переносит в окно с редактором профиля
        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window edit = new EditUser();
            edit.Show();
            this.Close();
        }
    }
}
