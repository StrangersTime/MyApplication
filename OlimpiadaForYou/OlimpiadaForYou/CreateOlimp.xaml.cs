using OlimpiadaForYou.database;
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
    /// Логика взаимодействия для CreateOlimp.xaml
    /// </summary>
    public partial class CreateOlimp : Window
    {
        public CreateOlimp()
        {
            InitializeComponent();
            cb_Class.ItemsSource = App.Context.Olimp_Class.Select(p => p.Interval).ToList();
            cb_Diff.ItemsSource = App.Context.Olimp_Difficulty.Select(p => p.Title).ToList();
            cb_Sub.ItemsSource = App.Context.Olimp_Subject.Select(p => p.Title).ToList();
        }

        private void ButReturn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CreatorWindow();
            window.Show();
            this.Close();
        }

        private void ButCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Title.Text != "" && tb_Descr.Text != "" && tb_Duration.Text != "" && cb_Class.Text != "" && cb_Diff.Text != "" && cb_Sub.Text != "" && dp_end.SelectedDate != null && dp_event.SelectedDate != null && tb_MaxGoal.Text != null)
            {
                var selectedClass = App.Context.Olimp_Class.Where(p => p.Interval == cb_Class.Text).Select(p => p.ID).FirstOrDefault();
                var selectedDif = App.Context.Olimp_Difficulty.Where(p => p.Title == cb_Diff.Text).Select(p => p.ID).FirstOrDefault();
                var selectedSub = App.Context.Olimp_Subject.Where(p => p.Title == cb_Sub.Text).Select(p => p.ID).FirstOrDefault();

                var newOlimp = new Olimp_Olimp
                {
                    ID_Creator = App._Olimp_Users.ID,
                    Title = tb_Title.Text,
                    Description = tb_Descr.Text,
                    Duration = tb_Duration.Text,
                    ID_Class = selectedClass,
                    ID_Difficulty = selectedDif,
                    ID_Subject = selectedSub,
                    DateOfEnd = (DateTime)dp_end.SelectedDate,
                    DateOfEvent = (DateTime)dp_event.SelectedDate,
                    MaxGoal = int.Parse(tb_MaxGoal.Text)
                };

                if (newOlimp != null)
                {
                    App.Context.Olimp_Olimp.Add(newOlimp);
                    App.Context.SaveChanges();

                    MessageBox.Show("Олимпиада добавлена успешно!");
                    if (MessageBox.Show("Хотите добавить ещё одну олимпиаду?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    {
                        CreatorWindow creatorWindow = new CreatorWindow();
                        creatorWindow.Show();
                        this.Close();
                    }
                }
            }
        }

        private void tb_Title_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\d"))
            {
                e.Handled = true;
            }
        }

        private void tb_Descr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\d"))
            {
                e.Handled = true;
            }
        }

        private void tb_MaxGoal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
