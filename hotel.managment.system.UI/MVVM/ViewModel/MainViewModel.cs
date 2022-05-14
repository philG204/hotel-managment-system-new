using GalaSoft.MvvmLight.Command;
using hotel.managment.system.UI.Core;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.managment.system.UI.MVVM.ViewModel
{   
    public class MainViewModel : ObservableObject
    {
        public RelayCommand BookingMaskViewCommand { get; set; }
        public RelayCommand ReceiptMaskViewCommand { get; set; }
        public RelayCommand EmployeeMaskViewCommand { get; set; }
        public RelayCommand CustomerMaskViewCommand { get; set; }

        public ViewModelBookingMask BookingMaskVM { get; set; }
        public ViewModelReceiptMask ReceiptMaskVM { get; set; }
        public ViewModelEmployeeMask EmployeeMaskVM { get; set; }
        public ViewModelCustomerMask CustomerMaskVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel()
        {
            BookingMaskVM = new ViewModelBookingMask();
            ReceiptMaskVM = new ViewModelReceiptMask();
            EmployeeMaskVM = new ViewModelEmployeeMask();
            CustomerMaskVM = new ViewModelCustomerMask();

            CurrentView = null;

            BookingMaskViewCommand = new RelayCommand(() => 
            { 
                CurrentView = BookingMaskVM;
            });

            ReceiptMaskViewCommand = new RelayCommand(() =>
            {
                CurrentView = ReceiptMaskVM;
            });

            EmployeeMaskViewCommand = new RelayCommand(() =>
            {
                CurrentView = EmployeeMaskVM;
            });

            CustomerMaskViewCommand = new RelayCommand(() =>
            {
                CurrentView = CustomerMaskVM;
            });
        }
    }
}
