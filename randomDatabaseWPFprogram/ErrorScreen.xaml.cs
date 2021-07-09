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

namespace randomDatabaseWPFprogram
{
    /// <summary>
    /// Interaction logic for ErrorScreen.xaml
    /// </summary>
    public partial class ErrorScreen : Window
    {
        public ErrorScreen(string ErrorMessage,string ErrorType)
        {
            InitializeComponent();
            ErrorMessageTextBox.Text += ErrorMessage;

            //Change Window size in way that is comfortable to read
            //Zmien wielkosc okna tak aby mozna bylo przyjemnie czytac

            if (ErrorType == "mysql")
            {
                ErrorScreenWindow.Width = 800;
                ErrorScreenWindow.Height = 650;

                ErrorScreenWindow.Title = "Database Error";
            }

            if (ErrorType == "credentials")
            {
                ErrorScreenWindow.Width = 210;
                ErrorScreenWindow.Height= 100;

                ErrorMessageTextBox.TextAlignment = TextAlignment.Center;

                ErrorScreenWindow.Title = "Error with logging in";
            }
        }
    }
}
