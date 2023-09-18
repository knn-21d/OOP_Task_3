using System.Linq;
using System.Windows;
using WpfApp3.Classes.Storages;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            PlayerStorage.Load();
            //RandomizedTest.Test(1000, 100000);
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            var player = PlayerStorage.PlayersList.FirstOrDefault(p => p.Login == loginTextBox.Text);
            if (player is null) MessageBox.Show($"Пользователь {loginTextBox.Text} не существует");
            else
            {
                new MainWindow(player).Show();
                Close();
            }
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            var player = PlayerStorage.PlayersList.FirstOrDefault(p => p.Login == loginTextBox.Text);
            if (player is null)
            {
                player = new Player(loginTextBox.Text);
                new MainWindow(player).Show();
                Close();
            }
            else MessageBox.Show($"Пользователь {loginTextBox.Text} уже существует");
        }
    }
}
