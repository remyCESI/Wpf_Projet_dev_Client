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

            string server = "51.210.103.59";
            string port = "3306";
            string database = "ProjetDev_db";
            string username = "admincesi";
            string password = "cesiexia";
            string vlogin = txtLogin.Text;
            string vpwd = txtPwd.Text;
            string vtoken = txtTk.Text;




            string connectionString = "server=" + server + ";port=" + port + ";database=" + database + ";uid=" + username + ";pwd=" + password + ";";
            MySqlConnection conMysql = new MySqlConnection(connectionString);
            try
            {
                conMysql.Open();
            MySqlCommand Sqlcmd = new MySqlCommand("SELECT count(1) FROM infoUser where login=@login AND pwd = sha1(@pwd) and token_app= @token", conMysql);

            Sqlcmd.CommandType = CommandType.Text;

            Sqlcmd.Parameters.AddWithValue("@login", vlogin);
            Sqlcmd.Parameters.AddWithValue("@pwd", vpwd);
            Sqlcmd.Parameters.AddWithValue("@token", vtoken);
            int count = Convert.ToInt32(Sqlcmd.ExecuteScalar());

                if (count == 1)
                {
                    Dechiffrement pdechiffrement = new Dechiffrement();
                    pdechiffrement.Show();
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
