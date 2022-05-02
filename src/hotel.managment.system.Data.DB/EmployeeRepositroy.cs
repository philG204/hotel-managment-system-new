using hotel_managment_system.Models;
using hotel_managment_system_v2.Repositories;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.Data.DB
{
    public class EmployeeRepositroy : IEmployeeRepository
    {
        public bool Delete(Employee obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Mitarbeiter` WHERE `Mitarbeiternummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.EmployeeID });

                var CheckDr = CheckCmd.ExecuteReader();
                    
                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Mitarbeiter` WHERE `Mitarbeiternummer` = ?", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EmployeeID });

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

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Mitarbeiter` WHERE `Mitarbeiternummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = id });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM `Mitarbeiter` WHERE `Mitarbeiternummer` = ?", connection);
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

        public Employee Get(int TId)
        {
            try
            {
                Employee employee = new Employee();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = TId });

                var dr = cmd.ExecuteReader();

                dr.Read();

                employee.EmployeeID = Convert.ToInt32(dr.GetValue(0));
                employee.Name = Convert.ToString(dr.GetValue(1));
                employee.Surename = Convert.ToString(dr.GetValue(2));
                employee.Street = Convert.ToString(dr.GetValue(3));
                employee.Housenumber = Convert.ToInt32(dr.GetValue(4));
                employee.PostalCode = Convert.ToInt64(dr.GetValue(5));
                employee.City = Convert.ToString(dr.GetValue(6));          
                employee.PhoneNumber = Convert.ToInt64(dr.GetValue(7));
                employee.Email = Convert.ToString(dr.GetValue(8));
                employee.Password = Convert.ToString(dr.GetValue(9));

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Kunde`", connection);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(dr.GetValue(0));
                    employee.Name = Convert.ToString(dr.GetValue(1));
                    employee.Surename = Convert.ToString(dr.GetValue(2));
                    employee.Street = Convert.ToString(dr.GetValue(3));
                    employee.Housenumber = Convert.ToInt32(dr.GetValue(4));
                    employee.PostalCode = Convert.ToInt64(dr.GetValue(5));
                    employee.City = Convert.ToString(dr.GetValue(6));
                    employee.PhoneNumber = Convert.ToInt64(dr.GetValue(7));
                    employee.Email = Convert.ToString(dr.GetValue(8));
                    employee.Password = Convert.ToString(dr.GetValue(9));

                    employees.Add(employee);
                }
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Employee obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Mitarbeiter` WHERE `Mitarbeiternummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.EmployeeID });

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows != false)
                {
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Mitarbeiter` (`Mitarbeiternummer`, `Vorname`, `Nachname`, `Straße`, `Hausnummer`, `Postleitzahl`, `Wohnort`, `Telefonnummer`, `E-Mail`, `Passwort`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EmployeeID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Name });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Surename });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Street });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Housenumber });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PostalCode });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.City });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PhoneNumber });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Email });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Password });

                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Mitarbeiter` SET `Vorname` = ?, `Nachname` = ?, `Straße` = ?, `Hausnummer` = ?, `Postleitzahl` = ?, `Wohnort` = ?, `Telefonnummer` = ?, `E-Mail` = ?, `Passwort` = ? WHERE `Mitarbeiternummer = ?`", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Name });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Surename });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Street });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Housenumber });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PostalCode });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.City });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PhoneNumber });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Email });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Password });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EmployeeID });

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
