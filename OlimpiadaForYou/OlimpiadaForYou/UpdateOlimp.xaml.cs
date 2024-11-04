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
    /// Логика взаимодействия для UpdateOlimp.xaml
    /// </summary>
    public partial class UpdateOlimp : Window
    {
        database.Olimp_Olimp _selectedOlimp;
        public UpdateOlimp(database.Olimp_Olimp selectedOlimp)
        {
            InitializeComponent();
            
            _selectedOlimp = selectedOlimp;

            cb_Class.ItemsSource = App.Context.Olimp_Class.Select(p => p.Interval).ToList();
            cb_Diff.ItemsSource = App.Context.Olimp_Difficulty.Select(p => p.Title).ToList();
            cb_Sub.ItemsSource = App.Context.Olimp_Subject.Select(p => p.Title).ToList();

            tb_Title.Text = selectedOlimp.Title;
            tb_Descr.Text = selectedOlimp.Description;
            tb_Duration.Text = selectedOlimp.Duration;
            tb_MaxGoal.Text = selectedOlimp.MaxGoal.ToString();

            dp_end.Text = selectedOlimp.DateOfEnd.ToString("yyyy-MM-dd") ?? string.Empty;
            dp_event.Text = selectedOlimp.DateOfEvent.ToString("yyyy-MM-dd") ?? string.Empty;
        }

            private void ButReturn_Click(object sender, RoutedEventArgs e)
        {
            OlimpCreator olimpCreator = new OlimpCreator();
            olimpCreator.Show();
            this.Close();
        }

        private void ButUpd_Click(object sender, RoutedEventArgs e)
        {
            var Class = App.Context.Olimp_Class.Where(p => p.Interval == cb_Class.Text).Select(p => p.ID).First();
            var Diff = App.Context.Olimp_Difficulty.Where(p => p.Title == cb_Diff.Text).Select(p => p.ID).First();
            var Sub = App.Context.Olimp_Subject.Where(p => p.Title == cb_Sub.Text).Select(p => p.ID).First();

            var updOlimp = App.Context.Olimp_Olimp.Find(_selectedOlimp.ID);
            if (updOlimp != null)
            {
                updOlimp.Title = tb_Title.Text;
                updOlimp.Description = tb_Descr.Text;
                updOlimp.Duration = tb_Duration.Text;
                updOlimp.MaxGoal = int.Parse(tb_MaxGoal.Text);

                if (dp_end.SelectedDate.HasValue)
                {
                    updOlimp.DateOfEnd = dp_end.SelectedDate.Value;
                }

                if (dp_event.SelectedDate.HasValue)
                {
                    updOlimp.DateOfEvent = dp_event.SelectedDate.Value;
                }

                updOlimp.ID_Class = Class;
                updOlimp.ID_Difficulty = Diff;
                updOlimp.ID_Subject = Sub;

                App.Context.SaveChanges();

                MessageBox.Show("Олимпиада успешно обновлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                OlimpCreator olimpCreator = new OlimpCreator();
                olimpCreator.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось найти олимпиаду для обновления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
