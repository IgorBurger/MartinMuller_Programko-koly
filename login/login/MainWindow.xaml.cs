using System.IO;
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

namespace login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool UsernameExists = false;
            
            try 
            {
                using (StreamReader sr = new StreamReader("UserDatabase.csv"))
                {
                    string input = sr.ReadLine();
                    
                    while (input != null)
                    {

                        string[] userData = input.Split(',');
                        if (userData[0] == RegUsername.Text)
                        {
                            UsernameExists = true;
                            UsernameError.Visibility = Visibility.Visible;
                            break;
                        }
                        input = sr.ReadLine();
                    }
                }
            }
            catch { }

            
            if (UsernameExists == false)
            {
                UsernameError.Visibility = Visibility.Hidden;
                Registered.Visibility = Visibility.Visible;
                using (StreamWriter sw = new StreamWriter("UserDatabase.csv", append: true))
                {
                    sw.WriteLine(RegUsername.Text + "," + RegPassword.Text + "," + RegQuote.Text);
                }
            }
            


           
        }

        private void Button_ClickLogIn(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("UserDatabase.csv")) 
            {
                string input = sr.ReadLine();
                while (input != null) 
                {

                    string[] userData = input.Split(',');
                    if (userData[0] == LogUsername.Text) 
                    {
                        if (userData[1] == LogPassword.Text)
                        {
                            LoginError.Visibility = Visibility.Hidden;
                            Test.Visibility = Visibility.Visible;
                        }
                        else 
                        {
                            LoginError.Visibility = Visibility.Visible;
                        }
                    }
                    else 
                    {
                        LoginError.Visibility = Visibility.Visible;
                    }
                    input = sr.ReadLine();
                }
                
            }
        }
    }
}