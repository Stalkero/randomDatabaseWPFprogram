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

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            switch (windowTheme)
            {
                case "dark":
                    NewDocumentWindow.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
                    CreateNewDocumentLabel.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                    DocumentFullMessageTextBox.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
                    DocumentFullMessageTextBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                    DocumentMessageLabel.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                    DocumentTitleLabel.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                    DocumentTitleTextBox.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
                    DocumentTitleTextBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                    RecipientsLabel.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    RecipientsTextBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    RecipientsTextBox.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));

                    SaveDocumentBtn.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    SaveDocumentBtn.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));

                    break;

                case "white":
                    NewDocumentWindow.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    CreateNewDocumentLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    DocumentFullMessageTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    DocumentFullMessageTextBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    DocumentMessageLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    DocumentTitleLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));


                    DocumentTitleTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    DocumentTitleTextBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    RecipientsLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    RecipientsTextBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    RecipientsTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    SaveDocumentBtn.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    SaveDocumentBtn.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    break;
                default:
                    break;
            }

            switch (programLang)
            {
                case "english":
                    NewDocumentWindow.Title = "Create new document";
                    CreateNewDocumentLabel.Text = "Create new document";
                    DocumentMessageLabel.Text = "Contents";
                    DocumentTitleLabel.Text = "Document title";
                    RecipientsLabel.Text = "Recipients";
                    SaveDocumentBtn.Content = "Save document";

                    break;

                case "polish":
                    NewDocumentWindow.Title = "Stwórz nowy dokument";
                    CreateNewDocumentLabel.Text = "Stwórz nowy dokument";
                    DocumentMessageLabel.Text = "Treść";
                    DocumentTitleLabel.Text = "Tytuł dokumentu";
                    RecipientsLabel.Text = "Odbiorcy";
                    SaveDocumentBtn.Content = "Zapisz dokument";

                    break;

                default:
                    break;
            }

        }
    }
}
