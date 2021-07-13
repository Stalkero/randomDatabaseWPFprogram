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
    /// Interaction logic for CreateNewDocumentWindow.xaml
    /// </summary>
    public partial class CreateNewDocumentWindow : Window
    {
        public CreateNewDocumentWindow(string programLang,string windowTheme)
        {
            InitializeComponent();




            switch (windowTheme)
            {
                case "dark":
                    NewDocumentWindow.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
                    break;

                case "white":
                    NewDocumentWindow.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    break;
                default:
                    break;
            }
        }
    }
}
