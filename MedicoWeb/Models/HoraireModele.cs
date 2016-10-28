using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicoWeb.Models
{
    public class HoraireModele
    {
        private int _idHoraire;

        public int IdHoraire
        {
            get { return _idHoraire; }
            set { _idHoraire = value; }
        }


        private string _jour;
        public string Jour
        {
            get { return _jour; }
            set { _jour = value; }
        }


        private DateTime _debMat;
        public DateTime DebMat
        {
            get { return _debMat; }
            set { _debMat = value; }
        }


        private DateTime _finMat;
        public DateTime FinMat
        {
            get { return _finMat; }
            set { _finMat = value; }
        }


        private DateTime _debAprem;
        public DateTime DebAprem
        {
            get { return _debAprem; }
            set { _debAprem = value; }
        }


        private DateTime _finAprem;
        public DateTime FinAprem
        {
            get { return _finAprem; }
            set { _finAprem = value; }
        }


        private DateTime _debDate;
        public DateTime DebDate
        {
            get { return _debDate; }
            set { _debDate = value; }
        }


        private DateTime _finDate;
        public DateTime FinDate
        {
            get { return _finDate; }
            set { _finDate = value; }
        }


        
        public List<HoraireModel> GetAll()
        {
            List<HoraireModel> LaListe = new List<HoraireModel>();
            // 1 - Connexion
            SqlConnection oConn = new SqlConnection();
                // chemin vers serveur (connection string)
            oConn.ConnectionString = @"Data Source=26R2-12\WADSQL;Initial Catalog=MedicoDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";    
                // ouvrir la connection
            try
            {
                oConn.Open();
                // 2 - Commande
                SqlCommand oCmd = new SqlCommand(@"SELECT * FROM Horaire 
                    WHERE DebDate <= GETDATE() and FinDate >= GETDATE()",oConn);
                // 3 - Execute
                SqlDataReader oDr = oCmd.ExecuteReader();
                // lire ttes les lignes
                 while (oDr.Read())
                 {
                     HoraireModel HM = new HoraireModel();
                     
                     HM.IdHoraire = (int)oDr["idHoraire"];
                     HM.Jour = oDr["Jour"].ToString();
                     HM.DebMat = (DateTime)oDr["DebMat"];
                     HM.FinMat = (DateTime)oDr["FinMat"];
                     HM.DebAprem = (DateTime)oDr["DebAprem"];
                     HM.FinAprem = (DateTime)oDr["FinAprem"];
                     HM.DebDate = (DateTime)oDr["DebDate"];
                     HM.FinDate = (DateTime)oDr["FinDate"];
                     return LaListe.Add(HM);
                 }
                // ferme reader
                 oDr.Close();
                // ferme connection
                 oConn.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
            return LaListe;
        }




    }
}