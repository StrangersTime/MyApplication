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
    /// Логика взаимодействия для CreatorWindow.xaml
    /// </summary>
    public partial class CreatorWindow : Window
    {
        public CreatorWindow()
        {
            InitializeComponent();

            if (App._Olimp_Users.Patronymic != "")
            {
                tb_NameTeacher.Text = App._Olimp_Users.Surname + " " + App._Olimp_Users.Name + " " + App._Olimp_Users.Patronymic + "!";
            }
            else tb_NameTeacher.Text = App._Olimp_Users.Surname + " " + App._Olimp_Users.Name + "!";

            CountPeopleFunction();
            Olimpiadas();
        }

        private int currentPage = 0;
        private const int itemsPerPage = 1;
        private List<OlimpViewModel> olimpsData;

        private void CountPeopleFunction()
        {
            var IdOlimp = App.Context.Olimp_Olimp
                .Where(p => p.ID_Creator == App._Olimp_Users.ID)
                .Select(p => p.ID)
                .ToList();

            var countReg = App.Context.Olimp_Registration
                .Where(p => IdOlimp.Contains((int)p.ID_Olimp))
                .Count();
            CountPeople.Text = countReg.ToString() + " ч.";
        }

        public class OlimpViewModel
        {
            public string Title { get; set; }
            public int CountRegistered { get; set; }
        }

        private void Olimpiadas()
        {
            olimpsData = App.Context.Olimp_Olimp
                .Where(r => r.ID_Creator == App._Olimp_Users.ID)
                .Select(r => new OlimpViewModel
                {
                    Title = r.Title,
                    CountRegistered = App.Context.Olimp_Registration
                        .Count(reg => reg.ID_Olimp == r.ID)
                })
                .ToList();

            UpdateListView();
        }

        private void UpdateListView()
        {
            if (olimpsData == null || !olimpsData.Any())
            {
                lv_Olimp.Visibility = Visibility.Collapsed;
                NoOlimpMessage.Visibility = Visibility.Visible;
                But_Back.Visibility = Visibility.Collapsed;
                But_Next.Visibility = Visibility.Collapsed;
                FocusOn.Visibility = Visibility.Collapsed;
                success.Text = "Не расстраивайтесь!";
                return;
            }

            lv_Olimp.Visibility = Visibility.Visible;
            NoOlimpMessage.Visibility = Visibility.Collapsed;

            var pagedData = olimpsData.Skip(currentPage * itemsPerPage).Take(itemsPerPage).ToList();
            lv_Olimp.ItemsSource = pagedData;

            But_Back.IsEnabled = currentPage > 0;
            But_Next.IsEnabled = (currentPage + 1) * itemsPerPage < olimpsData.Count;

            But_Back.Visibility = But_Back.IsEnabled ? Visibility.Visible : Visibility.Collapsed;
            But_Next.Visibility = But_Next.IsEnabled ? Visibility.Visible : Visibility.Collapsed;
        }
        private void But_Back_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                UpdateListView();
            }
        }

        private void But_Next_Click(object sender, RoutedEventArgs e)
        {
            if ((currentPage + 1) * itemsPerPage < olimpsData.Count)
            {
                currentPage++;
                UpdateListView();
            }
        }

        private void but_Return_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void ListOlimp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OlimpCreator olimpCreator = new OlimpCreator();
            olimpCreator.Show();
            this.Close();
        }

        private void CreateNew_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateOlimp createOlimp = new CreateOlimp();
            createOlimp.Show();
            this.Close();
        }

        private void ToLookInBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var image = sender as Image;

            if (image != null)
            {
                var button = FindParent<Button>(image);

                var olimpViewModel = button?.DataContext as OlimpViewModel;

                if (olimpViewModel != null)
                {
                    var olimpId = GetOlimpIdByTitle(olimpViewModel.Title);

                    ListUsers listUsers = new ListUsers(olimpId);
                    listUsers.Show();
                    this.Close();
                }
            }
        }

        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null) return null;

            T parent = parentObject as T;
            return parent ?? FindParent<T>(parentObject);
        }

        private int GetOlimpIdByTitle(string title)
        {
            return App.Context.Olimp_Olimp
                .Where(o => o.Title == title)
                .Select(o => o.ID)
                .FirstOrDefault();
        }
    }
}
