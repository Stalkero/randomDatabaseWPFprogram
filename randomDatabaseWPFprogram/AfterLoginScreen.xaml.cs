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
using MySql.Data.MySqlClient;

namespace randomDatabaseWPFprogram
{
    /// <summary>
    /// Interaction logic for AfterLoginScreen.xaml
    /// </summary>
    public partial class AfterLoginScreen : Window
    {
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


        public AfterLoginScreen(int userDatabaseId)
        {
            InitializeComponent();



            //Get which theme user had set 
            //Zdobac jaki motyw uzytkownik ma ustawiony 
            try
            {
                UserConfig config = new UserConfig();
                UserInfo info = new UserInfo();


                string serverConnectionString = "server=localhost;user=root;database=lawfirm;port=3306;password=";
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


                if (selectedThemeResults != null && selectedLangResults !=null && userName != null && userSurname != null )
                {
                

                    string selectedThemeResultsToString = Convert.ToString(selectedThemeResults);
                    string selectedLangResultsToString = Convert.ToString(selectedLangResults);
                    string userNameToString = Convert.ToString(userName);
                    string userSurnameToString = Convert.ToString(userSurname);


                    info.name = userNameToString;
                    info.surname = userSurnameToString;




                    switch (selectedLangResultsToString)
                    {
                        case "polish":
                            config.language = "polish";
                            AfterLoginScreenWindow.Title = "Polski";

                            WelcomeMessageText.Text = $"Witaj {info.name} {info.surname}.";

                            break;

                        case "english":
                            config.language = "english";
                            AfterLoginScreenWindow.Title = "English";

                            WelcomeMessageText.Text = $"Welcome {info.name} {info.surname}.";

                            break;

                        default:
                            break;
                    }




                    switch (selectedThemeResultsToString)
                    {
                        case "dark":
                            config.theme = "dark";
                            MainScreenGrid.Background = new SolidColorBrush(Color.FromRgb(50,50, 50));
                            WelcomeMessageText.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                            sqlConnection.Close();
                            break;

                        case "white":
                            config.theme = "white";
                            MainScreenGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                            WelcomeMessageText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));


                            sqlConnection.Close();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }






        }
    }
}
