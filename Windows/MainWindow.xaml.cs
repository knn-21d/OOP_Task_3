using System.Collections.Generic;
using System.Windows;
using WpfApp3.Windows;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player _player;
        public MainWindow(Player player)
        {
            InitializeComponent();
            _player = player;
            queueListBox.ItemsSource = _player.Queue.Games ?? new List<Game>();
            historyListBox.ItemsSource = _player.History;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            new PlanGame(_player).ShowDialog();
            queueListBox.Items.Refresh();
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            if (queueListBox.SelectedItem is null)
            {
                _player.Play();
            }
            else
            {
                _player.Play((Game)queueListBox.SelectedItem);
            }
            queueListBox.Items.Refresh();
            historyListBox.Items.Refresh();
        }

        private void PlayersButtonClick(object sender, RoutedEventArgs e)
        {
            new PlayersRatingWindow().Show();
        }

        private void GamesRatingButtonClick(object sender, RoutedEventArgs e)
        {
            new GamesRatingWindow().Show();
        }
    }
}
