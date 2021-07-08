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
        public AfterLoginScreen(int userDatabaseId)
        {
            InitializeComponent();

            userID_TextBox.Text += userDatabaseId;


            //Get which theme user had set 
            //Zdobac jaki motyw uzytkownik ma ustawiony 
            try
            {

                string serverConnectionString = "server=localhost;user=root;database=lawfirm;port=3306;password=";
                string themeSelectionQuery = $"SELECT t.theme FROM users u, user_theme_config t WHERE u.id = {userDatabaseId}";

                MySqlConnection sqlConnection = new MySqlConnection(serverConnectionString);

                sqlConnection.Open();

                MySqlCommand sqlCommand = new MySqlCommand(themeSelectionQuery, sqlConnection);
                object selectedThemeResults = sqlCommand.ExecuteScalar();

                if (selectedThemeResults != null)
                {
                    string selectedThemeResultsToString = Convert.ToString(selectedThemeResults);

                    switch (selectedThemeResultsToString)
                    {
                        case "dark":
                            MainScreenGrid.Background = new SolidColorBrush(Color.FromRgb(50,50, 50));

                            sqlConnection.Close();
                            break;

                        case "white":
                            MainScreenGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));


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
