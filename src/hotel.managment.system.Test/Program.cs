using hotel.managment.system.Service;
using hotel_managment_system;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace hotel.managment.system.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Receipt testing
            ReceiptService receiptService = new ReceiptService();
            
            Receipt receipt = CreateReceipt.GetReceipt();


            if (receiptService.Save(receipt))
            {
                Console.WriteLine("Object saved successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey();
            }           

            ObservableCollection<Receipt> receipts = receiptService.GetAll();

            foreach (Receipt r in receipts)
            {
                Console.WriteLine(r.ReceiptID.ToString() + r);
            }

            int n = 5;
            Console.WriteLine("\n");
            Receipt R = receiptService.Get(n);
            if (R != null)
            {
                Console.WriteLine(R.ReceiptID.ToString() + R);
            }
            else
            {
                Console.WriteLine("Entry dosen't exist");
            }


            Receipt receipt1 = new Receipt();
            receipt1.ReceiptID = 6;

            if (receiptService.Delete(receipt1))
            {
                Console.WriteLine("Entry deleted successfully");
            }
            else
            {
                Console.WriteLine("Something wen't wrong");
            }

            //Booking testing 
            BookingService bookingService = new BookingService();

            Booking booking = CreateBooking.GetBooking();

            if (receiptService.Save(receipt))
            {
                Console.WriteLine("Object saved successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey();
            }

            ObservableCollection<Booking> bookings = bookingService.GetAll();

            foreach (Booking b in bookings)
            {
                Console.WriteLine(b.BookingID.ToString() + b);
            }

            int m = 5;
            Console.WriteLine("\n");
            Booking B = bookingService.Get(m);
            if (B != null)
            {
                Console.WriteLine(B.BookingID.ToString() + B);
            }
            else
            {
                Console.WriteLine("Entry dosen't exist");
            }

            Booking booking1 = new Booking();
            booking1.BookingID = 6;

            if (bookingService.Delete(booking1))
            {
                Console.WriteLine("Entry deleted successfully");
            }
            else
            {
                Console.WriteLine("Something wen't wrong");
            }

            //Customer testing
            CustomerService customerService = new CustomerService();


            Customer customer = CreateCustomer.GetCustomer();
            
            if (customerService.Save(customer))
            {
                Console.WriteLine("Object saved successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey();
            }
            
            ObservableCollection<Customer> customers = customerService.GetAll();

            foreach (Customer c in customers)
            {
                Console.WriteLine(c.CustomerID + " " + c);
            }

            Console.WriteLine("\n");

            Customer customer1 = customerService.Get(6);
            
            if (customer1 == null)
            {
                Console.WriteLine("Entry not found");
            }
            else
            {
                Console.WriteLine(customer1.CustomerID + " " + customer1);
            }
          
            Customer customer3 = new Customer();
            customer3.CustomerID = 8;

            if (customerService.Delete(customer3))
            {
                Console.WriteLine("Entry sucessfully deleted");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            
            //Employee testing
            EmployeeService employeeService = new EmployeeService();


            Employee employee = CreateEmployee.GetEmployee();


            if (employeeService.Save(employee))
            {
                Console.WriteLine("Object successfully saved");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

            ObservableCollection<Employee> employees = employeeService.GetAll();

            foreach (Employee e in employees)
            {
                Console.WriteLine(e.EmployeeID + " " + e);
            }

            Console.WriteLine("\n");
            Employee employee3 = employeeService.Get(1);
            Console.WriteLine(employee.EmployeeID + " " + employee);

        }
    }
}
