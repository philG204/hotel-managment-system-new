using GalaSoft.MvvmLight.Command;
using hotel.managment.system.UI.UserControls;
using hotel.managment.system.UI.ViewModels;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace hotel.managment.system.UI
{
    public class ViewModelMainWindow : INotifyPropertyChanged
    {
        private object _currentView;
        private ICommand selectionViewModel;
        private ICommand referenceDataViewModel;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ViewModelMainWindow()
        {
            selectionViewModel = new RelayCommand(ChangeSelection);
            referenceDataViewModel = new RelayCommand(ChangeReferanceData);
        }

        private void ChangeReferanceData()
        {
            ViewModelReferenceData vmrd = new ViewModelReferenceData();
            _currentView = vmrd;
            MessageBox.Show(_currentView.ToString());
        }

        private void ChangeSelection()
        {
            ViewModelSelection vms = new ViewModelSelection();
            _currentView = vms;
            MessageBox.Show(_currentView.ToString());
        }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectionViewModel { get => selectionViewModel; set => selectionViewModel = value; }
        public ICommand ReferenceDataButton{ get => referenceDataViewModel; set => referenceDataViewModel = value; }

        protected void OnPropertyChanged([CallerMemberName] string _currentView = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_currentView));
        }
    }
}
