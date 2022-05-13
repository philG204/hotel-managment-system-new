using GalaSoft.MvvmLight.Command;
using hotel.managment.system.UI.UserControls;
using hotel.managment.system.UI.ViewModels;
using hotel_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace hotel.managment.system.UI
{
    public class ViewModelMainWindow
    {
        private object _currentView;
        
        public ViewModelMainWindow()
        {
            ViewModelSelection Selection = new ViewModelSelection();
            _currentView = Selection;
        }

        public object CurrentView { get => _currentView; set => _currentView = value; }
    }
}
