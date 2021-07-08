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

namespace randomDatabaseWPFprogram
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

        private void WhiteThemeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MW_Grid.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            WhiteThemeCheckBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            WhiteThemeCheckBox.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            

            user_login_Label.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_login_TextBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_login_TextBox.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));

            user_password_Label.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_password_TextBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_password_TextBox.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));

            user_login_Button.Background = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_login_Button.Foreground=  new SolidColorBrush(Color.FromRgb(50, 50, 50));

        }

        private void WhiteThemeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MW_Grid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            WhiteThemeCheckBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            WhiteThemeCheckBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            user_login_Label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            user_login_TextBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            user_login_TextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            user_password_Label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            user_password_TextBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            user_password_TextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            user_login_Button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            user_login_Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
    }
}
