using OlimpiadaForYou.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OlimpiadaForYou
{
    public partial class ListUsers : Window
    {
        private int _olimpId;
        private int _currentPage = 1;
        private const int _itemsPerPage = 5;
        private List<database.Olimp_Registration> _allRegistrations;

        public ListUsers(int olimpId)
        {
            InitializeComponent();
            _olimpId = olimpId;

            LoadRegistrations();
            UpdateDataGrid();
            UpdatePageNumber();
            UpdateButtonStates();
        }

        /// Загружает все регистрации участников для указанной олимпиады из базы данных.
        private void LoadRegistrations()
        {
            _allRegistrations = App.Context.Olimp_Registration
                .Where(r => r.ID_Olimp == _olimpId)
                .ToList();
        }

        /// Обновляет источник данных для DataGrid, отображая участников текущей страницы.
        private void UpdateDataGrid()
        {
            var participants = _allRegistrations
                .Skip((_currentPage - 1) * _itemsPerPage)
                .Take(_itemsPerPage)
                .ToList();

            DG_Users.ItemsSource = participants;
        }

        /// Обновляет текстовое поле, отображающее номер текущей страницы и общее количество страниц.
        private void UpdatePageNumber()
        {
            PageNumber.Text = $"Страница {_currentPage} из {Math.Ceiling((double)_allRegistrations.Count / _itemsPerPage)}";
            UpdateButtonStates();
        }

        /// Обновляет состояние кнопок навигации (Назад и Вперед) в зависимости от текущей страницы.
        private void UpdateButtonStates()
        {
            PreviousButton.IsEnabled = _currentPage > 1; 
            NextButton.IsEnabled = _currentPage < Math.Ceiling((double)_allRegistrations.Count / _itemsPerPage);
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdateDataGrid();
                UpdatePageNumber();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < Math.Ceiling((double)_allRegistrations.Count / _itemsPerPage))
            {
                _currentPage++;
                UpdateDataGrid();
                UpdatePageNumber();
            }
        }

        private void InResBut_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var row = button.DataContext as Olimp_Registration;

            if (row != null)
            {
                AddScore addScore = new AddScore(row.ID, row.Result, _olimpId); 
                addScore.Show();
                this.Close();
            }
        }

        private void ButReturn_Click(object sender, RoutedEventArgs e)
        {
            CreatorWindow creatorWindow = new CreatorWindow();
            creatorWindow.Show();
            this.Close();
        }
    }
}