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
    public class RoomRepository : IRoomRepository
    {
        public bool Delete(Room obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Zimmer` WHERE `Zimmernummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.RoomID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Zimmer` WHERE `Zimmernummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.RoomID });

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

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Zimmer` WHERE `Zimmernummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = id });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Zimmer` WHERE `Zimmernummer` = ?", connection);
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

        public Room Get(int TId)
        {
            try
            {
                Room r = new Room();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Zimmer` WHERE `Zimmernummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = TId });

                var dr = cmd.ExecuteReader();

                dr.Read();

                r.RoomID = Convert.ToInt32(dr.GetValue(0));
                r.Bed.BedID = Convert.ToInt32(dr.GetValue(1));
                r.RoomName = Convert.ToString(dr.GetValue(2));
                r.Price = Convert.ToDouble(dr.GetValue(3));
                r.Size = Convert.ToByte(dr.GetValue(4));
                r.NumberOfRooms = Convert.ToByte(dr.GetValue(5));
                r.Positon = Convert.ToString(dr.GetValue(6));
                r.Floor = Convert.ToString(dr.GetValue(7));
                r.SizeOfShower = Convert.ToByte(dr.GetValue(8));
                r.Equipment = Convert.ToString(dr.GetValue(9));
                r.Lightning = Convert.ToString(dr.GetValue(10));

                return r;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<Room> GetAll()
        {
            try
            {
                ObservableCollection<Room> rs = new ObservableCollection<Room>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Zimmer`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Room r = new Room();
                    r.RoomID = Convert.ToInt32(dr.GetValue(0));
                    r.Bed.BedID = Convert.ToInt32(dr.GetValue(1));
                    r.RoomName = Convert.ToString(dr.GetValue(2));
                    r.Price = Convert.ToDouble(dr.GetValue(3));
                    r.Size = Convert.ToByte(dr.GetValue(4));
                    r.NumberOfRooms = Convert.ToByte(dr.GetValue(5));
                    r.Positon = Convert.ToString(dr.GetValue(6));
                    r.Floor = Convert.ToString(dr.GetValue(7));
                    r.SizeOfShower = Convert.ToByte(dr.GetValue(8));
                    r.Equipment = Convert.ToString(dr.GetValue(9));
                    r.Lightning = Convert.ToString(dr.GetValue(10));                  

                    rs.Add(r);
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Room obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Zimmer` WHERE `Zimmernummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.RoomID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows == false)
                {

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Zimmer` (`Zimmernummer`, `Bettnummer`, `Zimmername`, `Preis`, `Größe`, `Zimmeranzahl`, `Lage`, `Boden`, `Duschengroeße`, `Ausstatung`, `Belechtung`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.RoomID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Bed.BedID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.RoomName });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Price });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Size });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.NumberOfRooms });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Positon });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Floor });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.SizeOfShower });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Equipment });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Lightning });

                    cmd.ExecuteNonQuery();

                    OleDbCommand Cmd1 = new OleDbCommand("SELECT * FROM `Aktion` ", connection);
                    Cmd1.ExecuteReader();

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Zimmer` SET `Bettnummer` = ?, `Zimmername` = ?, `Preis` = ?, `Größe` = ?, `Zimmeranzahl` = ?, `Lage` = ?, `Boden` = ?, `Duschengroeße` = ?, `Ausstatung` = ?, `Belechtung` = ? WHERE `Zimmernummer` = ?", connection);                   
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Bed.BedID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.RoomName });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Price });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Size });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.NumberOfRooms });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Positon });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Floor });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.SizeOfShower });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Equipment });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Lightning });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.RoomID });

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
