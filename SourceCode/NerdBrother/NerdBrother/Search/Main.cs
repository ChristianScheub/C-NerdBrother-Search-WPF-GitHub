using NerdBrother;
using NerdBrother.Search.BigSync.Forms;
using System;
using System.Data.OleDb;

namespace Suche
{

    public class Main { 

        #region VariablnDing
        static String Eingabe;
        public static int ReihenZahl;
        public static String get_eingabe() { return Eingabe; }
    #endregion VariablnDing


    #region StarteIrgFenster
    public static void StartMenu(string Eingabe1) //tÖffnet das Hauptfenster zum Ergebnis anzeigen
        {
            Eingabe = Eingabe1; //Dass die Eingabe in der Funktion auch hier abrufbar ist
            View Ergebnis = new View(); 
            Ergebnis.ShowDialog();
        }
        public static void StartDevOp()  //Öffnet das Fenster um Link hinzuzufügen
        {
            DevForm DevelopOp = new DevForm(); 
            DevelopOp.ShowDialog();
        }
        internal static void StartHome()  //Neue Suche bzw Fenster um Suche einzugeben
        {
            Form1 Home = new Form1(); 
            Home.Show();
        }

        internal static void StartBigSync()
        {
            BigSyncForm SyncForm = new BigSyncForm();
            SyncForm.Show();
        }
        #endregion StarteIrgFenster




    }

}