using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace randomDatabaseWPFprogram
{
    /// <summary>
    /// Interaction logic for AfterLoginScreen.xaml
    /// </summary>
    public partial class AfterLoginScreen : Window
    {
        public string selectedLang { get; set; }
        public string selectedTheme { get; set; }

        public string userDBid { get; set; }

        public class configFile
        {
            public string serverAddress { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string database { get; set; }
            public string port { get; set; }
        }

        public class LastDocumentsDataGridContent
        {
            public string title { get; set; }
            public string creationDate { get; set; }
            public string recipients { get; set; }
            public string DB_ID { get; set; }
        }

        public class RecipientsJson
        {
            public string recipients {get;set;}
        }

        public class UserConfig
        {
            public string theme { get; set; }
            public string language { get; set; }
        }
        public class UserInfo
        {
            public string name { get; set; }
            public string surname { get; set; }
        }


        public AfterLoginScreen(int userDatabaseId,string selectedLanguage)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            userDBid = userDatabaseId.ToString();

            try
            {
                string readedConfigFile = File.ReadAllText("config.config");
                configFile ConfigFile = JsonConvert.DeserializeObject<configFile>(readedConfigFile);

                //Get which theme user had set 
                //Zdobac jaki motyw uzytkownik ma ustawiony 
                try
                {
                    UserConfig config = new UserConfig();
                    UserInfo info = new UserInfo();

                    string serverConnectionString = $"server={ConfigFile.serverAddress};user={ConfigFile.username};database={ConfigFile.database};port={ConfigFile.port};password={ConfigFile.password}";
                    string themeSelectionQuery = $"SELECT c.theme,c.lang,d.name,d.surname FROM users u, user_config c,users_info_id d WHERE u.id = {userDatabaseId} AND c.user_id=u.id and d.info_id=u.id;";

                    MySqlConnection sqlConnection = new MySqlConnection(serverConnectionString);

                    sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand(themeSelectionQuery, sqlConnection);
                    MySqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    sqlReader.Read();

                    object selectedThemeResults = sqlReader[0];
                    object selectedLangResults = sqlReader[1];
                    object userName = sqlReader[2];
                    object userSurname = sqlReader[3];

                    if (selectedThemeResults != null && selectedLangResults != null && userName != null && userSurname != null)
                    { 
                        string selectedThemeResultsToString = Convert.ToString(selectedThemeResults);
                        string selectedLangResultsToString = Convert.ToString(selectedLangResults);
                        string userNameToString = Convert.ToString(userName);
                        string userSurnameToString = Convert.ToString(userSurname);


                        info.name = userNameToString;
                        info.surname = userSurnameToString;

                        selectedLang = selectedLangResultsToString;
                        selectedTheme = selectedThemeResultsToString;

                        switch (selectedLangResultsToString)
                        {
                            case "polish":
                                config.language = "polish";
                                AfterLoginScreenWindow.Title = "Polski";

                                WelcomeMessageText.Text = $"Witaj {info.name} {info.surname}.";
                                EditDocumentLabelTextBox.Text = "Edytuj Dokumenty";

                                LastDocumentsDataGrid.Columns[0].Header = "Tytuł";
                                LastDocumentsDataGrid.Columns[1].Header = "Data Utworzenia";
                                LastDocumentsDataGrid.Columns[2].Header = "Odbiorcy";
                                LastDocumentsDataGrid.Columns[3].Header = "DB_ID";
                                Add_new_document_BTN.Content = "Dodaj nowy dokument";
                                Change_settings_btn.Content = "Zmień ustawienia";

                                AfterLoginScreenWindow.Title = "Kancelaria Prawna: Menu główne";

                                break;

                            case "english":
                                config.language = "english";
                                AfterLoginScreenWindow.Title = "English";

                                WelcomeMessageText.Text = $"Welcome {info.name} {info.surname}.";
                                EditDocumentLabelTextBox.Text = "Edit documents";

                                LastDocumentsDataGrid.Columns[0].Header = "Title";
                                LastDocumentsDataGrid.Columns[1].Header = "Creation Date";
                                LastDocumentsDataGrid.Columns[2].Header = "Recipients";
                                LastDocumentsDataGrid.Columns[3].Header = "DB_ID";
                                Add_new_document_BTN.Content = "Add new documents";
                                Change_settings_btn.Content = "Change settings";
                                AfterLoginScreenWindow.Title = "Law Firm: Main menu";

                                break;

                            default:
                                break;
                        }

                        switch (selectedThemeResultsToString)
                        {
                            case "dark":
                                config.theme = "dark";
                                MainScreenGrid.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
                                WelcomeMessageText.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                                EditDocumentLabelTextBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                                LastDocumentsDataGrid.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
                                LastDocumentsDataGrid.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                Add_new_document_BTN.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
                                Add_new_document_BTN.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                                Change_settings_btn.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
                                Change_settings_btn.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                                sqlConnection.Close();
                                break;

                            case "white":
                                config.theme = "white";
                                MainScreenGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                                WelcomeMessageText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                EditDocumentLabelTextBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                LastDocumentsDataGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                                LastDocumentsDataGrid.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                                Add_new_document_BTN.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                                Add_new_document_BTN.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                                Change_settings_btn.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                                Change_settings_btn.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                                sqlConnection.Close();
                                break;
                            default:
                                break;
                        }

                        try
                        {
                            string getDocumentSQLquery = $"SELECT d.document_id, d.title,d.creationDate,d.recipients FROM users_documents d, users u WHERE d.creator_id = u.id AND u.id = {userDatabaseId} ";
                            MySqlConnection getDocumentsSqlConnection = new MySqlConnection(serverConnectionString);

                            getDocumentsSqlConnection.Open();

                            MySqlCommand getDocumentsSqlCommand = new MySqlCommand(getDocumentSQLquery, getDocumentsSqlConnection);
                            MySqlDataReader getDocumentsSqlReader = getDocumentsSqlCommand.ExecuteReader();

                            List<LastDocumentsDataGridContent> contents = new List<LastDocumentsDataGridContent>();

                            while (getDocumentsSqlReader.Read())
                            {
                                LastDocumentsDataGrid.Items.Add(new LastDocumentsDataGridContent() { title = getDocumentsSqlReader[1].ToString(), creationDate = getDocumentsSqlReader[2].ToString(), recipients = getDocumentsSqlReader[3].ToString(), DB_ID = getDocumentsSqlReader[0].ToString() });
                            }

                            getDocumentsSqlConnection.Close();

                        }
                        catch (Exception ex)
                        {
                            ErrorScreen errorScreen = new ErrorScreen(ex.ToString(), "gettingDocuments", selectedLangResultsToString);
                            errorScreen.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                ErrorScreen errorScreen = new ErrorScreen(ex.ToString(), "configFile", selectedLanguage);
                errorScreen.Show();
            }
        }

        private void EditDocumentBtn_Click(object sender, RoutedEventArgs e)
        {
            LastDocumentsDataGridContent content = (LastDocumentsDataGridContent)LastDocumentsDataGrid.SelectedItem;
            MessageBox.Show(content.DB_ID);
        }

        private void Add_new_document_BTN_Click(object sender, RoutedEventArgs e)
        {
            CreateNewDocumentWindow newDocumentWindow = new CreateNewDocumentWindow(selectedLang,selectedTheme,userDBid);
            newDocumentWindow.Show();
            this.Close();
        }
    }
}
