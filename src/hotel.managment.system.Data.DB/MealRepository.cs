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
    public class MealRepository : IMealRepository
    {
        public bool Delete(Meal obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Meal Get(int TId)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Meal> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Meal obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Speisen` WHERE `Speisennummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.MealID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows == false)
                {

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Speisen` (`Speisennummer`, `Bettnummer`, `Zimmername`, `Preis`, `Größe`, `Zimmeranzahl`, `Lage`, `Boden`, `Duschengroeße`, `Ausstatung`, `Belechtung`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MealID });
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
