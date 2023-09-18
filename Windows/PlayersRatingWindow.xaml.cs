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
using WpfApp3.Classes.Storages;

namespace WpfApp3.Windows
{
    /// <summary>
    /// Interaction logic for PlayersRatingWindow.xaml
    /// </summary>
    public partial class PlayersRatingWindow : Window
    {
        public PlayersRatingWindow()
        {
            InitializeComponent();
            playersDataGrid.ItemsSource = PlayerStorage.PlayersList;
        }
    }
}
