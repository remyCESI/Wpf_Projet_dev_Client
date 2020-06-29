using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Wpf_Projet_dev_Client
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

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {

            //information about the remote server
            string server = "51.210.103.59";
            string port = "3306";
            string database = "ProjetDev_db";
            string username = "admincesi";
            string password = "cesiexia";
            string vlogin = txtLogin.Text;
            string vpwd = txtPwd.Text;
            




            string connectionString = "server=" + server + ";port=" + port + ";database=" + database + ";uid=" + username + ";pwd=" + password + ";";
            MySqlConnection conMysql = new MySqlConnection(connectionString);
            try
            {

                conMysql.Open();

                //querie to check if the user's informations match
                MySqlCommand Sqlcmd = new MySqlCommand("SELECT count(1) FROM infoUser where login=@login AND pwd = sha1(@pwd)", conMysql);
                Sqlcmd.Parameters.AddWithValue("@login", vlogin);
                Sqlcmd.Parameters.AddWithValue("@pwd", vpwd);
            
                int count = Convert.ToInt32(Sqlcmd.ExecuteScalar());

                //if it exist a result do something 
                    if (count == 1)
                    {
                        //instance of the new windows called dechiffrement
                        Dechiffrement pdechiffrement = new Dechiffrement();
                        //to make the new windows visible
                        pdechiffrement.Show();
                        //close the connection
                        conMysql.Close();
                    }
                    else
                    {
                        NotifError.Visibility = Visibility.Visible;
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }





        }
    }
}
