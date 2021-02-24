using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Suche
{
    public partial class View : Form
    {


        DataSet ds = new DataSet();
        String url;
        int ReihenZahl;

        public void DB_abrufen()
        {
            String EingabeStart = Main.get_eingabe();

            string[] EingabeSplited = EingabeStart.Split(' ');
            string[] EingabeSplited1 = EingabeStart.Split(',');
            int EingabeAnz0 = EingabeSplited.Length;
            int EingabeAnz1 = EingabeSplited1.Length;
            DataTable dTable = Datenbank.DB_Abrufen("");



            for (int i = 0; i < EingabeAnz0; i++)
            {
                String EingabeOld0 = "\"" + EingabeSplited[i]+ "\"";
                Console.WriteLine("Es wird gesucht nach:   " +  EingabeSplited[i]);

                dTable.Merge(Datenbank.DB_Abrufen(EingabeOld0));
            }
            for (int i = 0; i < EingabeAnz1; i++)
            {
                String EingabeOld1 = "\"" + EingabeSplited1[i] + "\"";
                Console.WriteLine("Es wird gesucht nach:   " + EingabeSplited1[i]);

                dTable.Merge(Datenbank.DB_Abrufen(EingabeOld1));
            }




            dataGridView1.DataSource = dTable;



            ReihenZahl = dataGridView1.RowCount;
            Console.WriteLine(dataGridView1.RowCount);
        }


        private void SetDesign() //Design Elementarische Elemente die sonst nicht gehen
        {
            dataGridView1.RowHeadersVisible = false; //Der ist überflüssig und stört xD
            //Die Farben:
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView1.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#eceff1");
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, GraphicsUnit.Pixel);
            //Dass der Ganze Inhalt immer angezeigt wird:
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void DescRefresh()
        {
            Console.WriteLine("Reihen werden aktuallisiert wg Beschreibung");
            for (int i = 0; i < ReihenZahl; i++)
            {
                // i bedeutet die Spalte gerade
                url = dataGridView1.Rows[i].Cells[1].Value.ToString();

                #region LinkAbrufen
                String Name1 = dataGridView1[0, i].Value.ToString(); //Muss Link neu abrufen
                Name1 = "\"" + Name1 + "\"";

                using (var con = new OleDbConnection(
                                        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;"))
                {
                    con.Open();
                    using (var cmd1 = new OleDbCommand(
                                "SELECT Sites.Link FROM Sites WHERE Sites.Namen=" + Name1 + ";", con))
                    {
                        string tmp = cmd1.ExecuteScalar().ToString();
                        url = tmp;
                    }
                    con.Close();
                }
                Console.WriteLine("Link abgerufen.");
                #endregion





                url.Replace(@"\", ""); //Gab sonst manchmal Fehler


                Console.WriteLine("Link:  " + url);

                Meta Haupt = new Meta();
                String Desc = Meta.GetDescription(url); //Desc = Description; Holt die Beschreibung von der Webseite
                dataGridView1.Rows[i].Cells[1].Value = Desc; //Dass die neue Beschreibung auch angezeigt wird

                //Trägt die neue Beschreibung auch in die DB ein - sofern sie nicht leer ist
                String BearbeitName = dataGridView1.Rows[i].Cells[0].Value.ToString();

                if (!Desc.Equals(""))
                {
                    OleDbConnection conn = new OleDbConnection();
                    String bName = "\"" + BearbeitName + "\"";
                    String desc1 = Desc;
                    desc1 = desc1.Replace("\"", string.Empty);
                    desc1 = "\"" + desc1 + "\"";
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;";
                    String sql_Update = "UPDATE sites  SET Sites.Beschreibung =" + desc1 + " WHERE Sites.Namen =" + bName + ";";
                    Console.WriteLine(sql_Update);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql_Update, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            Console.WriteLine("Beschreibungen erfolgreich von allen abgerufen");
        }



        #region FormAktionen
        #region start
        public View() //Wird ausgeführt direkt beim starten
        {
            InitializeComponent();
            label_anfrage.Text = Main.get_eingabe();
        }
        private void View_Load(object sender, EventArgs e) //Wird ausgeführt wenn es geladen wurde
        {
            dataGridView1.Columns.Clear(); //Stellt sicher dass die Tabelle leer ist
            DB_abrufen(); //Füllt sie mit den Such-Ergebnissen
            SetDesign(); //Für den Design 
        }
        #endregion start
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Url;
            #region ErhoheAnzahlKlicks
            //Wenn man eine Spalte anklickt
            int ZeilePick = dataGridView1.CurrentRow.Index; //Zeile die Angeklickt wurde
            string Name1 = dataGridView1[0, ZeilePick].Value.ToString(); //Holt den Name aus der Tabelle der geklickt wurde
            Datenbank.DataKlick(Name1); //Erhöht den COunter von dem Link

            #region WebseiteÖffnen 
            Name1 = "\"" + Name1 + "\""; //Brauch es für die Datenbank Suche
            Url = Datenbank.getLink(Name1); //Holt den Link aus der Datenbank
            #endregion

            Console.WriteLine("Link wird nun geöffnet" + Url);
            System.Diagnostics.Process.Start(Url); //Startet den Link im Standard Browser
            #endregion
        } //Wenn eine Zelle angeklickt wurde
        private void button_refresh_Click(object sender, EventArgs e) //Button: Die Beschreibungen müssen aktualisiert werden
        {
            DescRefresh();       
        }
        private void button_settings_Click(object sender, EventArgs e) //Button: Einstellungen zum hinzufügen
        {
            Main.StartDevOp();
        }
        private void button_newSearch_Click(object sender, EventArgs e)
        {
            Main.StartHome();
        } //Button: Neue Suche machen
        #endregion FormAktionen


    }

}
