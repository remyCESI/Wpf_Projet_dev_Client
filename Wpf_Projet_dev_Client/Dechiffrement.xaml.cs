using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                   
                    lbFiles.Items.Add(Path.GetFileName(filename));
                    Textdisplay.Text = Textdisplay.Text + Environment.NewLine + File.ReadAllText(filename);
                   
                }
            }
            
        }
    }
}
