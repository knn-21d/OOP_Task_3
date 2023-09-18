using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp3.Classes.Games;
using WpfApp3.Classes.Storages;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for PlanGame.xaml
    /// </summary>
    public partial class PlanGame : Window
    {
        private readonly Player _player;
        private readonly List<Player> _playersList;

        public PlanGame(Player player)
        {
            InitializeComponent();
            _playersList = new(PlayerStorage.PlayersList);
            _playersList.Remove(player);
            _player = player;
            playersListBox.ItemsSource = _playersList;
        }

        private void CancelClick(object sender, RoutedEventArgs e) => Close();

        private void GameSelectionChanged(object sender, RoutedEventArgs e)
        {
            okButton.IsEnabled = gamesListBox.SelectedItems.Count > 0 ? true : false;
        }

        private void PlayerSelectionChanged(object sender, RoutedEventArgs e)
        {
            submitButton.IsEnabled = playersListBox.SelectedItems.Count > 0 ? true : false;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            gamesListBox.Visibility = Visibility.Hidden;
            okButton.Visibility = Visibility.Hidden;
            submitButton.Visibility = Visibility.Visible;
            playersListBox.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Visible;
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            gamesListBox.Visibility = Visibility.Visible;
            okButton.Visibility = Visibility.Visible;
            submitButton.Visibility = Visibility.Hidden;
            playersListBox.Visibility = Visibility.Hidden;
            backButton.Visibility = Visibility.Hidden;
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            var item = (ListBoxItem)gamesListBox.SelectedItem;
            var player2 = (Player)playersListBox.SelectedItem;
            switch (item.Content)
            {
                case "Backgammon":
                    Game game = new Backgammon(_player, player2);
                    _player.PlanGame(game);
                    player2.PlanGame(game);
                    break;
                case "Checkers":
                    game = new Checkers(_player, player2);
                    _player.PlanGame(game);
                    player2.PlanGame(game);
                    break;
                case "Chess":
                    game = new Chess(_player, player2);
                    _player.PlanGame(game);
                    player2.PlanGame(game);
                    break;
                case "Dominoes":
                    game = new Dominoes(_player, player2);
                    _player.PlanGame(game);
                    player2.PlanGame(game);
                    break;
                case "Monopoly":
                    game = new Monopoly(_player, player2);
                    _player.PlanGame(game);
                    player2.PlanGame(game);
                    break;
            }
            MessageBox.Show("Added successfully!");
            Close();
        }
    }
}
