﻿using hotel_managment_system.Models;
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
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Speisen` WHERE `Speisennummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.MealID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Speisen` WHERE `Speisennummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MealID });

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

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Speisen` WHERE `Speisennummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = id });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Speisen` WHERE `Speisennummer` = ?", connection);
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

        public Meal Get(int TId)
        {
            try
            {
                Meal meal = new Meal();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Speisen` WHERE `Speisennummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = TId });

                var dr = cmd.ExecuteReader();

                dr.Read();
               
                meal.MealID = Convert.ToInt32(dr.GetValue(0));
                meal.Name = Convert.ToString(dr.GetValue(1));
                meal.Price = Convert.ToDouble(dr.GetValue(2));

                OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM Rabatt INNER JOIN Speisen ON Rabatt.Rabattnummer = Speisen.Rabattnummer WHERE `Speisennummer` = ?", connection);
                cmd10.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                var DDr = cmd10.ExecuteReader();

                DDr.Read();
                Discount discount = new Discount();
                discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                discount.DiscountValue = Convert.ToDouble(DDr.GetValue(1));

                meal.discount = discount;

                return meal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<Meal> GetAll()
        {
            try
            {
                ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Speisen`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Meal meal = new Meal();
                    meal.MealID = Convert.ToInt32(dr.GetValue(0));
                    meal.Name = Convert.ToString(dr.GetValue(1));
                    meal.Price = Convert.ToDouble(dr.GetValue(2));

                    OleDbCommand cmd10 = new OleDbCommand("SELECT * FROM Rabatt INNER JOIN Speisen ON Rabatt.Rabattnummer = Speisen.Rabattnummer WHERE `Speisennummer` = ?", connection);
                    cmd10.Parameters.Add(new OleDbParameter { Value = dr.GetValue(0) });

                    var DDr = cmd10.ExecuteReader();

                    DDr.Read();
                    Discount discount = new Discount();
                    discount.DiscountID = Convert.ToInt32(DDr.GetValue(0));
                    discount.DiscountValue = Convert.ToDouble(DDr.GetValue(1));

                    meal.discount = discount;

                    meals.Add(meal);
                }
                return meals;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Speisen` (`Speisennummer`, `Name`, `Preis`, `Rabattnummer`) VALUES (?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MealID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Name });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Price });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.discount.DiscountID });                   

                    cmd.ExecuteNonQuery();

                    OleDbCommand Cmd1 = new OleDbCommand("SELECT * FROM `Speisen` ", connection);
                    Cmd1.ExecuteReader();

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Speisen` SET `Name` = ?, `Preis` = ?, `Rabattnummer` = ? WHERE `Speisennummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Name });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Price });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.discount.DiscountID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MealID });

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
