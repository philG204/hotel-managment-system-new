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
    public class TreatmentRepository : ITreatmentRepository
    {
        public bool Delete(Treatment obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Behandlung` WHERE `Behandlungsnnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Behandlung` WHERE `Behandlungsnnummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentID });

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

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Behandlung` WHERE `Behandlungsnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = id });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Behandlung` WHERE `Behandlungsnummer` = ?", connection);
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

        public Treatment Get(int TId)
        {
            try
            {
                Treatment treatment = new Treatment();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Behandlung` WHERE `Behandlungsnummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = TId });

                var dr = cmd.ExecuteReader();

                dr.Read();

                treatment.TreatmentID = Convert.ToInt32(dr.GetValue(0));
                treatment.TreatmentName = Convert.ToString(dr.GetValue(1));
                treatment.TreatmentAmount = Convert.ToDouble(dr.GetValue(2));

                OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM Rabatt INNER JOIN Behandlung ON Rabatt.Rabattnummer = Behandlung.Rabattnummer WHERE `Behandlungsnummer` = ?", connection);
                cmd10.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                var DDr = cmd10.ExecuteReader();

                DDr.Read();
                Discount discount = new Discount();
                discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                discount.DiscountValue = Convert.ToDouble(DDr.GetValue(1));

                treatment.discount = discount;

                return treatment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<Treatment> GetAll()
        {
            try
            {
                ObservableCollection<Treatment> treatments = new ObservableCollection<Treatment>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Behandlung`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Treatment treatment = new Treatment();
                    treatment.TreatmentID = Convert.ToInt32(dr.GetValue(0));
                    treatment.TreatmentName = Convert.ToString(dr.GetValue(1));
                    treatment.TreatmentAmount = Convert.ToDouble(dr.GetValue(2));

                    OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM Rabatt INNER JOIN Behandlung ON Rabatt.Rabattnummer = Behandlung.Rabattnummer WHERE `Behandlungsnummer` = ?", connection);
                    cmd10.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var DDr = cmd10.ExecuteReader();

                    DDr.Read();
                    Discount discount = new Discount();
                    discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                    discount.DiscountValue = Convert.ToDouble(DDr.GetValue(1));

                    treatment.discount = discount;

                    treatments.Add(treatment);
                }
                return treatments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Treatment obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Behandlung` WHERE `Behandlungsnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows == false)
                {

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Behandlung` (`Behandlungsnummer`, `Name`, `Preis`, `Rabattnummer`) VALUES (?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentName });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentAmount });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.discount.DiscountID });

                    cmd.ExecuteNonQuery();

                    OleDbCommand Cmd1 = new OleDbCommand("SELECT * FROM `Behandlung` ", connection);
                    Cmd1.ExecuteReader();

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Behandlung` SET `Name` = ?, `Preis` = ?, `Rabattnummer` = ? WHERE `Behandlungsnummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentName });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentAmount });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.discount.DiscountID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.TreatmentID });

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
