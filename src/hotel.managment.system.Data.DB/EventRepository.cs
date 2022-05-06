using hotel_managment_system;
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
    public class EventRepository : IEventRepository
    {
        public bool Delete(Event obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Mitarbeiter` WHERE `Mitarbeiternummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.EventID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Mitarbeiter` WHERE `Mitarbeiternummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EventID });

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

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Aktion` WHERE `Aktionsnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = id });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Aktion` WHERE `Aktionsnummer` = ?", connection);
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

        public Event Get(int TId)
        {
            try
            {
                Event e = new Event();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Aktion` WHERE `Aktionsnummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = TId });

                var dr = cmd.ExecuteReader();

                dr.Read();

                e.EventID = Convert.ToInt32(dr.GetValue(0));
                e.EventName = Convert.ToString(dr.GetValue(1));
                e.DiscountValue = Convert.ToInt32(dr.GetValue(2));

                return e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<Event> GetAll()
        {
            try
            {
                ObservableCollection<Event> es = new ObservableCollection<Event>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Aktion`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Event e = new Event();
                    e.EventID = Convert.ToInt32(dr.GetValue(0));
                    e.EventName = Convert.ToString(dr.GetValue(1));
                    e.DiscountValue = Convert.ToInt32(dr.GetValue(2));

                    es.Add(e);
                }
                return es;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Event obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Aktion` WHERE `Aktionsnummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.EventID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows == false)
                {

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Aktion` (`Aktionsnummer`, `Aktionsname`, `Rabattwert`, `Aktion_von`, `Aktion_bis`) VALUES (?, ?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EventID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EventName });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountValue });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.From });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.To });

                    cmd.ExecuteNonQuery();

                    OleDbCommand Cmd1 = new OleDbCommand("SELECT * FROM `Aktion` ", connection);
                    Cmd1.ExecuteReader();

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Aktion` SET `Aktionsname` = ?, `Rabattwert` = ?, `Aktion_von` = ?, `Aktion_bis` = ? WHERE `Aktionsnummer = ?`", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EventName });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.DiscountValue });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.From });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.To });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EventID });

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
