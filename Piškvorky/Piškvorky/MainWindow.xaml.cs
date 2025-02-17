using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WtfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel vm = new ViewModel(WinMessage);
            vm.GenerateButtons(gameBoard);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var test in gameBoard.Children) 
            {
                if(test is Button) 
                {
                    ((Button)test).Content = null;
                    WinMessage.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}