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

            for (int i = 1; i < 0; i++)
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

            /**
            if (receiptService.Save(receipt))
            {
                Console.WriteLine("Object saved successfully");
            }
            else
            {
                Console.WriteLine("Somethiing went wrong");
                Console.ReadKey();
            }
            **/

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
            receipt1.ReceiptID = 5;

            if (receiptService.Delete(receipt1))
            {
                Console.WriteLine("Entry deleted successfully");
            }
            else
            {
                Console.WriteLine("Somethin wen't wrong");
            }
            
        }
    }
}
