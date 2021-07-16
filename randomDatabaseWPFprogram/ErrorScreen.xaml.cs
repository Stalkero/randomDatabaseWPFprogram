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
        public ErrorScreen(string ErrorMessage,string ErrorType,string lang)
        {
            InitializeComponent();
            ErrorMessageTextBox.Text += ErrorMessage;

            //Change Window size in way that is comfortable to read
            //Zmien wielkosc okna tak aby mozna bylo przyjemnie czytac

            switch (lang)
            {
                case "Polski":

                    switch (ErrorType)
                    {
                        case "gettingDocuments":
                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            ErrorScreenWindow.Title = "Nie udało się pobrać dokumentów";
                            break;

                        case "configFile":
                            ErrorScreenWindow.Title = "Błąd podczas odczytu/zapisu pliku konfiguracyjnego";

                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            break;

                        case "credentials":
                            if (ErrorMessage == "Failed to login")
                                ErrorMessageTextBox.Text = "Nie udało się zalogować";

                            ErrorScreenWindow.Title = "Błąd podczas logowania";
                            ErrorScreenWindow.Width = 210;
                            ErrorScreenWindow.Height = 100;

                            ErrorMessageTextBox.TextAlignment = TextAlignment.Center;

                            break;

                        case "mysql":
                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            ErrorScreenWindow.Title = "Błąd bazy danych";

                            break;
                        default:
                            break;
                    }
                    break;

                case "English":

                    switch (ErrorType)
                    {
                        case "gettingDocuments":
                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            ErrorScreenWindow.Title = "Failed to retrieve documents";
                            break;

                        case "configFile":
                            ErrorScreenWindow.Title = "Error while reading/saving configuration file";

                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            break;

                        case "credentials":
                            ErrorScreenWindow.Title = "Error while logging in";
                            ErrorScreenWindow.Width = 210;
                            ErrorScreenWindow.Height = 100;

                            ErrorMessageTextBox.TextAlignment = TextAlignment.Center;

                            break;

                        case "mysql":
                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            ErrorScreenWindow.Title = "Database error";

                            break;

                        default:
                            break;
                    }

                    break;

                //Please someone add translation for German
                case "German":

                    switch (ErrorType)
                    {
                        case "gettingDocuments":
                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            ErrorScreenWindow.Title = "Dokumente konnten nicht abgerufen werden";
                            break;

                        case "configFile":
                            ErrorScreenWindow.Title = "Fehler beim Lesen/Speichern der Konfigurationsdatei";

                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            break;

                        case "credentials":
                            ErrorScreenWindow.Title = "Fehler beim Einloggen";
                            ErrorScreenWindow.Width = 210;
                            ErrorScreenWindow.Height = 100;

                            ErrorMessageTextBox.TextAlignment = TextAlignment.Center;

                            break;

                        case "mysql":
                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            ErrorScreenWindow.Title = "Fehler in der Datenbank";

                            break;

                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }

        }
    }
}
