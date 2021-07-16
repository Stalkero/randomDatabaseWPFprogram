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
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.IO;

namespace randomDatabaseWPFprogram
{
    /// <summary>
    /// Interaction logic for CreateNewDocumentWindow.xaml
    /// </summary>
    public partial class CreateNewDocumentWindow : Window
    {

        public string userDatabaseID { get; set; }
        public string selectedLang { get; set; }

        public class configFile
        {
            public string serverAddress { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string database { get; set; }
            public string port { get; set; }
        }

        public CreateNewDocumentWindow(string programLang, string windowTheme,string userDB)
        {
            InitializeComponent();

            userDatabaseID = userDB;
            selectedLang = programLang;

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();


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

                    LiveTimeLabel.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                    break;

                case "white":
                    NewDocumentWindow.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    CreateNewDocumentLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

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

                    LiveTimeLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    break;
                default:
                    break;
            }

            switch (programLang)
            {

                //Thx kindlessly
                case "german":
                    NewDocumentWindow.Title = "Neues Dokument erstellen";
                    CreateNewDocumentLabel.Text = "Neues Dokument erstellen";
                    DocumentMessageLabel.Text = "Inhalt";
                    DocumentTitleLabel.Text = "Dokument Titel";
                    RecipientsLabel.Text = "Empfänger";
                    SaveDocumentBtn.Content = "Dokument speichern";

                    break;

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

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void SaveDocumentBtn_Click(object sender, RoutedEventArgs e)
        {
            string documentMessage = DocumentTitleTextBox.Text;

            TextRange message = new TextRange(
                DocumentFullMessageTextBox.Document.ContentStart,
                DocumentFullMessageTextBox.Document.ContentEnd
            );

            string recipients = RecipientsTextBox.Text;

            try
            {
                string readedConfigFile = File.ReadAllText("config.config");
                configFile ConfigFile = JsonConvert.DeserializeObject<configFile>(readedConfigFile);

                string serverConnectionString = $"server={ConfigFile.serverAddress};user={ConfigFile.username};database={ConfigFile.database};port={ConfigFile.port};password={ConfigFile.password}";

                string sqlQuery = $"INSERT INTO `users_documents` (`document_id`, `title`, `message`, `creator_id`, `recipients`, `creationDate`) VALUES (NULL, '{documentMessage}', '{message.Text}', '{userDatabaseID}', '{recipients}', current_timestamp())";

                MySqlConnection sqlConnection = new MySqlConnection(serverConnectionString);

                sqlConnection.Open();

                MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);


                try
                {
                    sqlCommand.ExecuteNonQuery();

                    AfterLoginScreen afterLoginScreen = new AfterLoginScreen(Convert.ToInt32(userDatabaseID), selectedLang);
                    afterLoginScreen.Show();

                    this.Close();

                }
                catch (Exception ex)
                {
                    ErrorScreen error = new ErrorScreen(ex.ToString(), "mysql", selectedLang);
                    error.Show();
                }

            }
            catch (Exception ex)
            {
                ErrorScreen errorScreen = new ErrorScreen(ex.ToString(), "configFile", selectedLang);
                errorScreen.Show();

            }
            



            

        }
    }
}
