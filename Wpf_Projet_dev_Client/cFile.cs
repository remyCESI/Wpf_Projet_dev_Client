﻿namespace Wpf_Projet_dev_Client
{
    public class cFile
    {
        public string nom { get; set; }
        public string contenu { get; set; }

        public cFile()
        {

        }
        public cFile( string nom, string contenu)
        {
            this.nom = nom;
            this.contenu = contenu;

        }



    }
}