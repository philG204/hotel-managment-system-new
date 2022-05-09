using GalaSoft.MvvmLight.Command;
using hotel.managment.system.Service;
using hotel_managment_system;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace hotel.managment.system.UI.UserControls
{
    class ViewModelBookingMask
    {
        // Needed Services
        private BookingService bookingService = new BookingService();
        private EventService eventService = new EventService();
        private BreakfastService breakFastService = new BreakfastService();
        private EmployeeService employeeService = new EmployeeService();    
        private CustomerService customerService = new CustomerService();
        private RoomService roomService = new RoomService();
        private MealService mealService = new MealService();
        private TreatmentService treatmentService = new TreatmentService();

        private ICommand save;
        private ICommand delete;
        private ICommand edit;
        private ICommand goBack;
        private ICommand addRoom;
        private ICommand removeRoom;
        private ICommand addMeal;
        private ICommand removeMeal;
        private ICommand addTreatment;
        private ICommand removeTreatment;

        private Booking model;

        private ObservableCollection<string> breakfastsNames = new ObservableCollection<string>();
        private ObservableCollection<string> eventNames = new ObservableCollection<string>();
        private ObservableCollection<string> employeeNames = new ObservableCollection<string>();
        private ObservableCollection<string> customerNames = new ObservableCollection<string>();
        private ObservableCollection<string> roomNames = new ObservableCollection<string>();
        private ObservableCollection<string> mealNames = new ObservableCollection<string>();
        private ObservableCollection<string> treatmentNames = new ObservableCollection<string>();
        ObservableCollection<Booking> bookings = new ObservableCollection<Booking>();

        private ObservableCollection<string> mealListBox = new ObservableCollection<string>();

        private string selectedRoomComboBox;
        private string selectedRoomListBox;
        private string selectedMealComboBox;
        private string selectedMealListBox;
        private string selectedTreatmentComboBox;
        private string selectedTreatmentListBox;

        public ViewModelBookingMask()
        {
            goBack = new RelayCommand(GoBackCommand);
            save = new RelayCommand(SaveCommand);
            delete = new RelayCommand(DeleteCommand);
            edit = new RelayCommand(EditCommand);
            addRoom = new RelayCommand(Add_Room);
            removeRoom = new RelayCommand(Remove_Room);
            removeMeal = new RelayCommand(Remove_Meal);
            addMeal = new RelayCommand(Add_Meal);
            removeMeal = new RelayCommand(Remove_Treatment);
            addMeal = new RelayCommand(Add_Treatment);

            model = new Booking();

            //Load all neccessary objects
            ObservableCollection<Breakfast> breakfasts = breakFastService.GetAll();
            foreach (Breakfast breakfast in breakfasts)
            {
                breakfastsNames.Add(breakfast.KindOfBreakfast);
            }

            ObservableCollection<Event> events = eventService.GetAll();
            foreach (Event e in events)
            {
                eventNames.Add(e.EventName + " " + e.DiscountValue.ToString());
            }

            ObservableCollection<Employee> employees = employeeService.GetAll();
            foreach (Employee employee in employees)
            {
                employeeNames.Add(employee.Name + " " + employee.Surename.ToString());
            }

            ObservableCollection<Customer> customers = customerService.GetAll();
            foreach (Customer customer in customers)
            {
                customerNames.Add(customer.CustomerID + " " + customer.Name + " " + customer.Surname.ToString());
            }

            ObservableCollection<Room> rooms = roomService.GetAll();
            foreach (Room r in rooms)
            {
                roomNames.Add(r.RoomID + " " + r.RoomName);
            }

            ObservableCollection<Meal> meals = mealService.GetAll();
            foreach (Meal m in meals)
            {
                mealNames.Add(m.MealID + " " + m.Name);
                mealListBox.Add(m.MealID + " " + m.Name);
            }

            ObservableCollection<Treatment> treatments = treatmentService.GetAll();
            foreach (Treatment t in treatments)
            {
                treatmentNames.Add(t.TreatmentID + " " + t.TreatmentName);
            }

            bookings = bookingService.GetAll();
            
        }

        private void Add_Room()
        {
            ObservableCollection<Room> rooms = roomService.GetAll();
            foreach (Room room in rooms)
            {
                if (room.RoomName == selectedRoomComboBox)
                {
                    model.Room.Rooms.Add(room);
                }
            }
        }

        private void Remove_Room()
        {
            ObservableCollection<Room> rooms = roomService.GetAll();
            foreach (Room room in rooms)
            {
                if (room.RoomName == selectedRoomComboBox)
                {
                    model.Room.Rooms.Remove(room);
                }
            }
        }

        private void Add_Treatment()
        {
            ObservableCollection<Treatment> treatments = treatmentService.GetAll();
            foreach (Treatment treatment in treatments)
            {
                if (treatment.TreatmentName == selectedTreatmentComboBox)
                {
                    model.TotalTreatmentCosts.Treatments.Add(treatment);
                }
            }
        }

        private void Remove_Treatment()
        {
            ObservableCollection<Treatment> treatments = treatmentService.GetAll();
            foreach (Treatment treatment in treatments)
            {
                if (treatment.TreatmentName == selectedTreatmentComboBox)
                {
                    model.TotalTreatmentCosts.Treatments.Remove(treatment);
                }
            }
        }
        private void Add_Meal()
        {
            /**
            ObservableCollection<Meal> meals = mealService.GetAll();
            foreach (Meal meal in meals)
            {
                if (meal.Name == selectedMealComboBox.Split(" ")[1])
                {
                    model.Room.Rooms.Add(room);
                    mealListBox.Add();
                }
            }
            **/
        }

        private void Remove_Meal()
        {
            ObservableCollection<Room> rooms = roomService.GetAll();
            foreach (Room room in rooms)
            {
                if (room.RoomName == selectedRoomComboBox)
                {
                    model.Room.Rooms.Remove(room);
                }
            }
        }

        
        private void GoBackCommand()
        {
            //Moves back to previous ViewModel
        }
        private void DeleteCommand() 
        {
            //Delete...
        }
        private void EditCommand()
        {
            //Edit...
        }
        private void SaveCommand()
        {
            MessageBox.Show("Test");

            /**
            if (model.Room == null)
            {
                Console.WriteLine("Sie müsssen ein Zimmer buchen");
            }
            else
            {
                //Booking objeect is getting saved
                bookingService.Save(model);
            }
            **/
        }
        public string SelectedMealComboBox { get => selectedMealComboBox; set => selectedMealComboBox = value; }
        public string SelectedMealListBox { get => selectedMealListBox; set => selectedMealListBox = value; }
        public string SelectedTreatmentComboBox { get => selectedMealComboBox; set => selectedMealComboBox = value; }
        public string SelectedTreatmentListBox { get => selectedMealListBox; set => selectedMealListBox = value; }
        public string SelectedRoomComboBox { get => selectedRoomComboBox; set => selectedRoomComboBox = value; }
        public string SelectedRoomListBox { get => selectedRoomListBox; set => selectedRoomListBox = value; }
        public ObservableCollection<string> MealNames { get => mealNames; }
        public ObservableCollection<string> TreatmentNames { get => treatmentNames; }
        public ObservableCollection<string> RoomNames { get => roomNames; }
        public ObservableCollection<string> EventNames { get => eventNames; }
        public ObservableCollection<string> BreakfastsNames { get => breakfastsNames; }
        public ObservableCollection<string> EmployeeNames { get => employeeNames; }
        public ObservableCollection<string> CustomerNames { get => customerNames; }
        public ObservableCollection<Booking> Bookings { get => bookings; }
        public int BookinID { get => model.BookingID; set => model.BookingID = value; }
        public string SelectedMethodOfPayment { get => model.MethodOfPayment; set => model.MethodOfPayment = value; }
        public Breakfast SelectedBreakfast { get => model.Breakfast; set => model.Breakfast = value; }
        public Event SelectedEvent { get => model.Event; set => model.Event = value; }
        public double Amount { get => model.Amount; set => model.Amount = value; }
        public bool Settel { get => model.settel; set => model.settel = value; }
        public DateTime DepatureTime { get => model.Depature; set => model.Depature = value; }
        public DateTime ArrivalTime { get => model.Arrival; set => model.Arrival = value; }
        public Employee SelectedEmployee { get => model.SubEmployee.Employee; set => model.SubEmployee.Employee = value; }
        public Customer SelectedCustomer { get => model.Customer; set => model.Customer = value; }
        public ICommand Save { get => save; set => save = value; }
        public ICommand Delete { get => delete; set => delete = value; }
        public ICommand Edit { get => edit; set => edit = value; }
        public ICommand GoBack { get => goBack; set => goBack = value; }
        public ICommand AddRoom { get => addRoom; set => addRoom = value; }
        public ICommand RemoveRoom { get => removeRoom; set => removeRoom = value; }
        public ICommand AddTreatment { get => addTreatment; set => addTreatment = value; }
        public ICommand RemoveTreatment { get => removeTreatment; set => removeTreatment = value; }
    }
}
