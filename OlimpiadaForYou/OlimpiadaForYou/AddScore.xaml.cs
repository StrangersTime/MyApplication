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
    /// Логика взаимодействия для AddScore.xaml
    /// </summary>
    public partial class AddScore : Window
    {
        private int _participantId;
        private int? _currentResult;
        private int _olimpId;

        public AddScore(int participantId, int? currentResult, int olimpId)
        {
            InitializeComponent();
            _participantId = participantId;
            _currentResult = currentResult;
            _olimpId = olimpId;

            if (_currentResult.HasValue)
            {
                ResultTextBox.Text = _currentResult.Value.ToString();
            }
            else
            {
                ResultTextBox.Text = string.Empty;
            }
        }

        private void But_Upd_Click(object sender, RoutedEventArgs e)
        {
            var adding = App.Context.Olimp_Registration.Find(_participantId);
            if (adding != null)
            {
                adding.Result = int.Parse(ResultTextBox.Text);

                App.Context.SaveChanges();
                MessageBox.Show("Все прошло успешно!");

                ListUsers listUsers = new ListUsers(_olimpId);
                listUsers.Show();
                this.Close();
            }
        }

        private void But_Return_Click(object sender, RoutedEventArgs e)
        {
            ListUsers listUsers = new ListUsers(_olimpId); 
            listUsers.Show();
            this.Close();
        }
    }
}
