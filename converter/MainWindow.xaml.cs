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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace converter
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

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderTextBox.Text = Slider.Value.ToString();
        }

        private void SliderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double number;
            if (double.TryParse(SliderTextBox.Text, out number))
            {
                Slider.Value = number;
            }
            else
            {
                Slider.Value = 0;
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            switch (MorCM.Text)
            {
                case "cm":
                    calculate(Slider.Value / 100);
                    break;
                case "m":
                    calculate(Slider.Value);
                    break;
                default: break;
            }
        }

        private void calculate(double m)
        {
            switch (DMorKM.Text)
            {
                case "dm":
                    Result.Text = $"{m * 10}";
                    changeImgToSmile();
                    break;
                case "km":
                    Result.Text = $"{m / 1000}";
                    changeImgToSmile();
                    break;
            }
        }

        private void changeImgToSmile()
        {
            Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("/img/smile.png", UriKind.Relative));
        }
    }
}
