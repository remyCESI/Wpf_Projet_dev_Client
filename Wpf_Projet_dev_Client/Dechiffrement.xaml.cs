using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Wpf_Projet_dev_Client
{
    /// <summary>
    /// Logique d'interaction pour Dechiffrement.xaml
    /// </summary>
    public partial class Dechiffrement : Window
    {
       
        public Dechiffrement()
        {
            InitializeComponent();
        }

        private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        {

             //new Instance of openfiledialog to handle file throught graphic interface 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            //you can only upload a file that is text
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //we start the dialog box in document folder
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //instance of List object cfile type
            List<cFile> lfile = new List<cFile>();

            

            if (openFileDialog.ShowDialog() == true)
            {
                //that means for each file upload do something 
                foreach (string filename in openFileDialog.FileNames)
                {
                   
                    //we put the filename in a list in order to remind the user about his push
                    lbFiles.Items.Add(Path.GetFileName(filename));

                    //optional
                    Textdisplay.Text = Textdisplay.Text + Environment.NewLine + File.ReadAllText(filename);

                    //add in lfile some information like name and contains in order to send to middleware later by json
                    lfile.Add(new cFile(){nom = Path.GetFileName(filename) ,contenu = File.ReadAllText(filename)});

                    
                }

                //we serialise en json the list that contains all information about the push with one or several files 
                string json = JsonConvert.SerializeObject(lfile);

            }
            
        }
    }
}
