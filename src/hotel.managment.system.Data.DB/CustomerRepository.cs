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
    public class CustomerRepository : ICustomerRepository
    {
        public bool Delete(Customer obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("DELETE FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = obj.CustomerID });

                cmd.ExecuteNonQuery();

                OleDbCommand cmd2 = new OleDbCommand("DELETE FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                cmd2.Parameters.Add(new OleDbParameter { Value = obj.CustomerID });

                cmd2.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("DELETE FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = id});

                cmd.ExecuteNonQuery();

                OleDbCommand cmd2 = new OleDbCommand("DELETE FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                cmd2.Parameters.Add(new OleDbParameter { Value = id });

                cmd2.ExecuteNonQuery();

                return true;
            }          
            catch (Exception ex)
            {
                throw ex;
                return false;
            }            
        }

        public Customer Get(int TId)
        {
            try
            {
                Customer customer = new Customer();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = TId});

                var dr = cmd.ExecuteReader();

                if (dr.HasRows != false)
                {
                    dr.Read();

                    customer.CustomerID = Convert.ToInt32(dr.GetValue(0));
                    customer.Name = Convert.ToString(dr.GetValue(1));
                    customer.Surname = Convert.ToString(dr.GetValue(2));
                    customer.Street = Convert.ToString(dr.GetValue(3));
                    customer.HouseNumber = Convert.ToString(dr.GetValue(4));
                    customer.PostalCode = Convert.ToInt64(dr.GetValue(5));
                    customer.City = Convert.ToString(dr.GetValue(6));
                    customer.KindOfTravaler = Convert.ToString(dr.GetValue(7));
                    customer.PhoneNumber = Convert.ToInt64(dr.GetValue(8));
                    customer.Email = Convert.ToString(dr.GetValue(9));
                    customer.Birthday = Convert.ToDateTime(dr.GetValue(10));
                    customer.Gender = Convert.ToString(dr.GetValue(11));
                    customer.MaritalStatus = Convert.ToString(dr.GetValue(12));
                    customer.EducationalStatus = Convert.ToString(dr.GetValue(13));
                    customer.Vocation = Convert.ToString(dr.GetValue(14));

                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM `Kunde`", connection);

                var dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = Convert.ToInt32(dr.GetValue(0));
                    customer.Name = Convert.ToString(dr.GetValue(1));
                    customer.Surname = Convert.ToString(dr.GetValue(2));
                    customer.Street = Convert.ToString(dr.GetValue(3));
                    customer.HouseNumber = Convert.ToString(dr.GetValue(4));
                    customer.PostalCode = Convert.ToInt64(dr.GetValue(5));
                    customer.City = Convert.ToString(dr.GetValue(6));
                    customer.KindOfTravaler = Convert.ToString(dr.GetValue(7));
                    customer.PhoneNumber = Convert.ToInt64(dr.GetValue(8));
                    customer.Email = Convert.ToString(dr.GetValue(9));
                    customer.Birthday = Convert.ToDateTime(dr.GetValue(10));
                    customer.Gender = Convert.ToString(dr.GetValue(11));
                    customer.MaritalStatus = Convert.ToString(dr.GetValue(12));
                    customer.EducationalStatus = Convert.ToString(dr.GetValue(13));
                    customer.Vocation = Convert.ToString(dr.GetValue(14));

                    customers.Add(customer);
                }
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Customer obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB_Abrechnung.accdb");
                connection.Open();

                OleDbCommand CheckCmd = new OleDbCommand("SELECT * FROM `Kunde` WHERE `Kundennummer` = ?", connection);
                CheckCmd.Parameters.Add(new OleDbParameter { Value = obj.CustomerID});

                var CheckDr = CheckCmd.ExecuteReader();

                if (CheckDr.HasRows == false)
                {          

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO `Kunde` (`Kundennummer`, `Vorname`, `Nachname`, `Straße`, `Hausnummer`, `Postleitzahl`, `Wohnort`, `Art_Reisender`, `Telefonnummer`, `E-Mail`, `Geburtstag`, `Geschlecht`, `Familienstand`, `Bildungsstand`, `Berufung`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.CustomerID });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Name });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Surname });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Street });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.HouseNumber });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PostalCode });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.City });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.KindOfTravaler });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PhoneNumber });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Email });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Birthday });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Gender });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MaritalStatus });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EducationalStatus });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Vocation });

                    cmd.ExecuteNonQuery();

                    OleDbCommand Cmd1 = new OleDbCommand("SELECT * FROM `Kunde` ", connection);
                    Cmd1.ExecuteReader();

                    return true;
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("UPDATE `Kunde` SET `Vorname` = ?, `Nachname` = ?, `Straße` = ?, `Hausnummer` = ?, `Postleitzahl` = ?, `Wohnort` = ?, `Art_Reisender` = ?, `Telefonnummer` = ?, `E-Mail` = ?, `Geburtstag` = ?, `Geschlecht` = ?, `Familienstand` = ?, `Bildungstand` = ?, `Berufung` = ? WHERE `Kundennummer = ?`", connection);
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Name });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Surname });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Street });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.HouseNumber });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PostalCode });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.City });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.KindOfTravaler });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.PhoneNumber });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Email });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Birthday });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Gender });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.MaritalStatus });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.EducationalStatus });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.Vocation });
                    cmd.Parameters.Add(new OleDbParameter { Value = obj.CustomerID });

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
