using hotel_managment_system.Models;
using hotel_managment_system_v2.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Data.DB
{
    public class DiscountRepository : IDisountRepository
    {
        public bool Delete(Discount obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Rabatt` WHERE `Rabattnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Rabatt` WHERE `Rabattnummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountID });

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

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Rabatt` WHERE `Rabattnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = id });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Rabatt` WHERE `Rabattnummer` = ?", connection);
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

        public Discount Get(int TId)
        {
            try
            {
                Discount e = new Discount();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Rabatt` WHERE `Rabattnummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = TId });

                var dr = cmd.ExecuteReader();

                dr.Read();

                e.DiscountID = Convert.ToInt32(dr.GetValue(0));
                e.DiscountValue = Convert.ToInt32(dr.GetValue(2));

                return e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<Discount> GetAll()
        {
            try
            {
                ObservableCollection<Discount> es = new ObservableCollection<Discount>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Rabatt`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Discount e = new Discount();
                    e.DiscountID = Convert.ToInt32(dr.GetValue(0));
                    e.DiscountValue = Convert.ToInt32(dr.GetValue(1));

                    es.Add(e);
                }
                return es;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Discount obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Rabatt` WHERE `Aktionsnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows == false)
                {

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Rabatt` (`Rabattnummer`, `Rabattwert`) VALUES (?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountValue });
                    cmd.ExecuteNonQuery();

                    OleDbCommand Cmd1 = new OleDbCommand("SELECT * FROM `Rabatt` ", connection);
                    Cmd1.ExecuteReader();

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Rabatt` SET `Rabattnummer` = ?, `Rabattwert` = ? WHERE `Aktionsnummer = ?`", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountValue });
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
