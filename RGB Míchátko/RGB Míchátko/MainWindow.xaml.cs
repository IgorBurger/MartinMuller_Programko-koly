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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RGB_Míchátko
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

        private void SliderR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Boxik.Fill = new SolidColorBrush(Color.FromRgb((byte)((Slider)sender).Value, (byte)SliderG.Value, (byte)SliderB.Value));
            txtR.Text = Convert.ToString(((Slider)sender).Value);
        }

        private void SliderG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Boxik.Fill = new SolidColorBrush(Color.FromRgb((byte)SliderR.Value, (byte)((Slider)sender).Value, (byte)SliderB.Value));
            txtG.Text = Convert.ToString(((Slider)sender).Value);
        }

        private void SliderB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Boxik.Fill = new SolidColorBrush(Color.FromRgb((byte)SliderR.Value, (byte)SliderG.Value, (byte)((Slider)sender).Value));
            txtB.Text = Convert.ToString(((Slider)sender).Value);
        }

        private void TextBoxR_TextChanged(object sender, TextChangedEventArgs e)
        {
            try 
            {
                int txtBoxValue = Convert.ToInt32(((TextBox)sender).Text);
                if (txtBoxValue > 255)
                {
                    ErrorBox.Opacity = 100;
                }
                else 
                {
                    SliderR.Value = txtBoxValue;
                    Boxik.Fill = new SolidColorBrush(Color.FromRgb((byte)txtBoxValue, (byte)SliderG.Value, (byte)SliderB.Value));
                    ErrorBox.Opacity = 0;
                }
            }
            catch
            {
                //ErrorBox.Opacity = 100;
            }
        }

        private void TextBoxG_TextChanged(object sender, TextChangedEventArgs e)
        {
            try 
            { 
                int txtBoxValue = Convert.ToInt32(((TextBox)sender).Text);
                if (txtBoxValue > 255)
                {
                    ErrorBox.Opacity = 100;
                }
                else 
                {
                    SliderG.Value = txtBoxValue;
                    Boxik.Fill = new SolidColorBrush(Color.FromRgb((byte)SliderR.Value, (byte)txtBoxValue, (byte)SliderB.Value));
                    ErrorBox.Opacity = 0;
                }
            }
            catch 
            {
                //ErrorBox.Opacity = 100;
            }
        }

        private void TextBoxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try 
            { 
                int txtBoxValue = Convert.ToInt32(((TextBox)sender).Text);
                if (txtBoxValue > 255)
                {
                    ErrorBox.Opacity = 100;
                }
                else
                {
                    SliderB.Value = txtBoxValue;
                    Boxik.Fill = new SolidColorBrush(Color.FromRgb((byte)SliderR.Value, (byte)SliderG.Value, (byte)txtBoxValue));
                    ErrorBox.Opacity = 0;
                }
            }
            catch 
            {
                //ErrorBox.Opacity = 100;
            }
}

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(cc => Char.IsNumber(cc));
            base.OnPreviewTextInput(e);
        }
    }
}