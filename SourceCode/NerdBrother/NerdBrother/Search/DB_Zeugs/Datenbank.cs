using System;
using System.Data;
using System.Data.OleDb;

namespace Suche
{
    public class Datenbank
    {
       // String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;";

        #region SucheUndView
        public static void DataKlick(String NamePicked1)
        {
            OleDbConnection conn = new OleDbConnection();
            String NamePicked = "\"" + NamePicked1 + "\"";
            String sql_Update = "UPDATE Sites Set Klicks = Klicks+1 WHERE Namen = " + NamePicked + ";";
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql_Update, conn);
            cmd.ExecuteNonQuery();
        } //erhöht den Wert in der Anzeige (wird danach sortiert); WENN geklickt wurde
        public static DataTable DB_Abrufen(String EingabeOld)
        {
            DataTable dTable = new DataTable();
            if (!EingabeOld.Equals(""))
            {
                String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;";
                String sql_callDb = "SELECT Sites.Namen,  Sites.Beschreibung, Sites.Abrufdatum FROM Sites, Beziehung, Art WHERE Art.TypName =" + EingabeOld + " AND Beziehung.ID_Typ=Art.ID_Typ AND Beziehung.Webseite_ID=Sites.ID_Webseite GROUP BY Sites.Namen ,Sites.Beschreibung, Sites.Klicks,  Sites.Abrufdatum ORDER BY Sites.Klicks DESC;";
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sql_callDb, connString);
                OleDbCommandBuilder cBuilder = new OleDbCommandBuilder(dAdapter);
                dAdapter.Fill(dTable);
                return dTable;
            }
            return dTable;
        } //Wenn die Suche ausgeführt wird
        public static void DB_enter_des(string bearbeitName, string desc)
        {
            if (!desc.Equals(""))
            {
                String bName = "\"" + bearbeitName + "\"";
                String sql_Update = "UPDATE sites  SET beschreibung =" + desc + " WHERE Namen =" + bName + ";";
                Console.WriteLine(sql_Update);
                OleDbConnection conn = new OleDbConnection
                {
                    ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;"
                };
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql_Update, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        } //Falls die Beschreibung einer Webseite aktuallisiert wurde
        #endregion SucheUndView


        #region WebseiteHinzuFügen
        public static void DB_NewSite(String URL1, String TitelWeb)
        {
            string sql = null;
            //DER TAG Wurde gefunden
            TitelWeb = TitelWeb.Replace("\"", "-");
            String Zeichen2 = "\"";
            String URL2 = "\"" + URL1 + "\"";
            DateTime thisDay = DateTime.Today;
            String sql_Update = sql = "INSERT INTO Sites (Namen, Link, Klicks,Abrufdatum) VALUES(" + Zeichen2 + TitelWeb + Zeichen2 + "," + URL2 + " ,0 "+","+Zeichen2+ thisDay.ToString("d")+Zeichen2 + ")";
            Console.WriteLine(sql_Update);
            OleDbConnection conn = new OleDbConnection
            {
                ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;"
            };
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql_Update, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }  //Fügt die Webseite zur DB hinzu
        public static int DB_WebsiteID(string URL4)
        {
            //ID Abrufen
            String Zeichen2 = "\"";
            int WebseiteID = 2;
            using (var con = new OleDbConnection(
                        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;"))
            {
                con.Open();
                using (var cmd1 = new OleDbCommand(
                            "SELECT ID_Webseite FROM Sites WHERE Sites.Link=" + Zeichen2 + URL4 + Zeichen2 + ";", con))
                {
                    try
                    {
                        var tmp1 = Convert.ToInt64(cmd1.ExecuteScalar()); WebseiteID = Convert.ToInt32(tmp1);
                    }
                    catch (OleDbException ex)
                    {
                        // Fehleeer aufgetreten xD

                        Console.WriteLine("LOL FEHLER HAHAHHAHA");
                    }
                }
                con.Close();
            }
            Console.WriteLine("Done.");
            return WebseiteID;
        } //holt die ID der Webseite basierend auf den URL
        public static void TagAdd(string b_Tag1)
        {
            //DER TAG Wurde gefunden
            String b_tag5 = "\"" + b_Tag1 + "\"";
            String sql_Update = "INSERT INTO Art (TypName) VALUES( " + b_tag5 + ")";
            Console.WriteLine(sql_Update);
            OleDbConnection conn = new OleDbConnection
            {
                ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;"
            };
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql_Update, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine("Tag hinzugefügt: " + b_tag5);
        }  //Fügt den tag in die Tabelle "Tags" ein
        public static int[] TagID(string b_Tag1)
        {
            int[] back = new int[2];
            using (var con = new OleDbConnection(
                        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;"))
            {
                con.Open();
                using (var TypIdA = new OleDbCommand(
                            "SELECT Art.ID_Typ FROM Art WHERE Art.TypName =" + "\"" + b_Tag1 + "\"" + ";", con))
                {
                    try
                    {
                        var tmp = TypIdA.ExecuteScalar();
                    }
                    catch (OleDbException ex)
                    {
                        // Fehleeer aufgetreten xD

                        Console.WriteLine("LOL FEHLER HAHAHHAHA");
                    }


                    finally
                    {
                        var tmp = TypIdA.ExecuteScalar();
                        if (tmp != null)
                        {
                            String TypNU2 = tmp.ToString(); //Die Id als String
                            int TypNu1 = Int32.Parse(TypNU2); //ID als INT
                            Console.WriteLine("Typ ID ist: " + TypNU2);

                            back[1] = TypNu1;
                            back[0] = 0;
                           
                        }
                        else
                        {
                            //Tag nicht gefunden
                            back[0] = 10;
                           
                            
                        }
                    }
                }
            }
            return back;
        }
        public static void DB_Beziehung(int ID_Typ, int ID_Website)
        {
            String sql_intoBez = "INSERT INTO Beziehung (Webseite_ID, ID_Typ) VALUES(" + ID_Website + "," + ID_Typ + ");";
            Console.WriteLine(sql_intoBez);
            OleDbConnection conn = new OleDbConnection
            {
                ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;"
            };
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql_intoBez, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        } //Macht die Beziehung zwischen den Tags und der Webseite in Table: Beziehung
        #endregion WebseiteHinzuFügen


        public static string getLink(string name)
        {
            string url = "";
            using (var con = new OleDbConnection(
                                     @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Search\DB_Zeugs\Webseiten1.mdb; Persist Security Info=False;"))
            {
                con.Open();
                using (var cmd1 = new OleDbCommand(
                            "SELECT Sites.Link FROM Sites WHERE Sites.Namen=" + name + ";", con))
                {
                    url = cmd1.ExecuteScalar().ToString();
                    
                }
                con.Close();
            }
            return url;
        }
    }
}