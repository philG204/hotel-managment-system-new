using hotel_managment_system;
using hotel_managment_system_v2.Repositories;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Data.DB
{
    public class BreakfastRepository : IBreakfastRepository
    {
        public bool Delete(Breakfast obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Frühstück` WHERE `Frühstücksnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.BreakfastID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Frühstück` WHERE `Frühstücksnummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.BreakfastID });

                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Frühstück` WHERE `Frühstücksnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = id });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Frühstück` WHERE `Frühstücksnummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = id });

                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }

        public Breakfast Get(int TId)
        {
            try
            {
                Breakfast breakFast = new Breakfast();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Frühstück` WHERE `Frühstücksnummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = TId });

                var dr = cmd.ExecuteReader();

                dr.Read();

                breakFast.BreakfastID = Convert.ToInt32(dr.GetValue(0));
                breakFast.KindOfBreakfast = Convert.ToString(dr.GetValue(1));
                breakFast.AdditionAmount = Convert.ToInt32(dr.GetValue(2));

                return breakFast;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Breakfast> GetAll()
        {
            try
            {
                List<Breakfast> breakFasts = new List<Breakfast>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Frühstück`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Breakfast breakFast = new Breakfast();
                    breakFast.BreakfastID = Convert.ToInt32(dr.GetValue(0));
                    breakFast.KindOfBreakfast = Convert.ToString(dr.GetValue(1));
                    breakFast.AdditionAmount = Convert.ToInt32(dr.GetValue(2));

                    breakFasts.Add(breakFast);
                }
                return breakFasts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Breakfast obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Frühstück` WHERE `Frühstücksnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.BreakfastID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows == false)
                {

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Frühstück` (`Frühstücksnummer`, `Frühstücksart`, `Zusatzbetrag`) VALUES (?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.BreakfastID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.KindOfBreakfast });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.AdditionAmount });

                    cmd.ExecuteNonQuery();

                    OleDbCommand Cmd1 = new OleDbCommand("SELECT * FROM `Aktion` ", connection);
                    Cmd1.ExecuteReader();

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Frühstück` SET `Frühstücksname` = ?, `Zusatzbetrag` = ? WHERE `Frühstücksnummer = ?`", connection);    
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.KindOfBreakfast });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.AdditionAmount });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.BreakfastID });

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
    }
}
