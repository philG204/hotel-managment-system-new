using hotel.managment.system.Service;
using hotel_managment_system;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;

namespace hotel.managment.system.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            /**
            ReceiptService receiptService = new ReceiptService();

            Receipt receipt = new Receipt();

            receipt.ReceiptID = 6;

            Customer customer = new Customer();
            customer.CustomerID = 1;
            customer.Street = "street";
            customer.City = "city";
            customer.Name = "name";
            customer.MaritalStatus = "S1";
            customer.KindOfTravaler = "traveler";
            customer.EducationalStatus = "ES1";
            customer.Birthday = new DateTime();
            customer.Email = "test@test.com";
            customer.Gender = "gender1";
            customer.HouseNumber = "123ab";
            customer.PhoneNumber = 1233441;
            customer.PostalCode = 13414;
            customer.Surname = "surename";

            receipt.Customer = customer;

            receipt.PaymentDate = new DateTime();
            receipt.MethodOfPayment = "card";
            receipt.CashAmount = 54.70;
            receipt.settel = true;

            SubEmployee Sub_employee = new SubEmployee();
            Sub_employee.Date = new DateTime();

            Employee employee = new Employee();
            employee.EmployeeID = 1;
            employee.Name = "Name1";
            employee.Street = "street";
            employee.Email = "test@test.com";
            employee.Surename = "surename";
            employee.City = "city";
            employee.Housenumber = 1234;
            employee.PhoneNumber = 12344;
            employee.PostalCode = 12343424;
            employee.Password = "password420";

            Sub_employee.Employee = employee;

            receipt.SubEmployee = Sub_employee;

            TotalMealCosts totelMealCost = new TotalMealCosts();


            for (int i = 1; i < 1; i++)
            {
                Meal meal = new Meal();
                meal.MealID = i;
                meal.Name = "Speise" + i;
                meal.Price = 15;

                Discount disount = new Discount();
                disount.DiscountID = 2;
                disount.DiscountValue = 10;

                meal.discount = disount;

                totelMealCost.Meals.Add(meal);
            }

            totelMealCost.MealCost = 60;
            totelMealCost.discount = 0;

            receipt.TotalMealCosts = totelMealCost;


            TotalTreatmentCosts totalTreatmentCost = new TotalTreatmentCosts();

            for (int i = 1; i < 2; i++)
            {
                Treatment treatment = new Treatment();
                treatment.TreatmentID = i;
                treatment.TreatmentName = "Speise" + i;
                treatment.TreatmentAmount = 15;

                Discount disount = new Discount();
                disount.DiscountID = 2;
                disount.DiscountValue = 10;

                treatment.discount = disount;

                totalTreatmentCost.Treatments.Add(treatment);
            }

            totalTreatmentCost.AmountTreatmentCosts = 30;
            totalTreatmentCost.Discount = 0;

            receipt.TotalTreatmentCosts = totalTreatmentCost;

            
            if (receiptService.Save(receipt))
            {
                Console.WriteLine("Object saved successfully");
            }
            else
            {
                Console.WriteLine("Somethiing went wrong");
                Console.ReadKey();
            }
            

            List<Receipt> receipts = receiptService.GetAll();

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
            

            CustomerService customerService = new CustomerService();
            
            
            Customer customer = new Customer();
            customer.CustomerID = 9;
            customer.Name = "Name9";
            customer.Surname = "Surename9";
            customer.Street = "Street9";
            customer.City = "City9";
            customer.Email = "email9.@email.com";
            customer.Vocation = "Vocation9";
            customer.MaritalStatus = "maritalStatus9";
            customer.KindOfTravaler = "KindOfTravaler9";
            customer.Birthday = new DateTime();
            customer.EducationalStatus = "EducationalStatus9";
            customer.HouseNumber = "9";
            customer.PhoneNumber = 1234567;
            customer.Gender = "gender9";
            customer.PostalCode = 1234;
            
            if (customerService.Save(customer))
            {
                Console.WriteLine("Object saved successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey();
            }
            
            List<Customer> customers = customerService.GetAll();

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


            
            Customer customer2 = new Customer();
            customer2.CustomerID = 8;

            if (customerService.Delete(customer2))
            {
                Console.WriteLine("Entry sucessfully deleted");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            **/

            EmployeeService employeeService = new EmployeeService();

            
            Employee employee = new Employee();

            employee.EmployeeID = 3;
            employee.Name = "Name3";
            employee.Surename = "Surename3";
            employee.Street = "street3";
            employee.Housenumber = 3;
            employee.PhoneNumber = 1234;
            employee.City = "city3";
            employee.Email = "email3@.com";
            employee.PostalCode = 123145;
            employee.Password = "passwwort1234";


            if (employeeService.Save(employee))
            {
                Console.WriteLine("Object successfully saved");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

            List<Employee> employees = employeeService.GetAll();

            foreach (Employee e in employees)
            {
                Console.WriteLine(e.EmployeeID + " " + e);
            }

            Console.WriteLine("\n");
            Employee employee2 = employeeService.Get(1);
            Console.WriteLine(employee2.EmployeeID + " " + employee2);

        }
    }
}
