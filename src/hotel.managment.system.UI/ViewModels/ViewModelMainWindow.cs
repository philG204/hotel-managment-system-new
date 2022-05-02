using GalaSoft.MvvmLight.Command;
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
        RelayCommand _SelectingInvoive;
        RelayCommand _ShowSelectingControlCommand;
        private bool _IsUserControl1Collapsed = true;

        //public RelayCommand 
        public RelayCommand ShowUserControl1Command
        {
            get
            {
                if (_ShowSelectingControlCommand == null)
                {
                    _ShowSelectingControlCommand = new RelayCommand(() => ChangeValue());
                }
                return _ShowSelectingControlCommand;
            }
            set
            {
                if (_ShowSelectingControlCommand == null)
                {
                    _ShowSelectingControlCommand = new RelayCommand(() => ChangeValue());
                }
                _ShowSelectingControlCommand = value;
            }
        }

        public void ChangeValue()
        {
            if (_IsUserControl1Collapsed == false)
            {
                _IsUserControl1Collapsed = true;
            }
            else
            {
                _IsUserControl1Collapsed = false;
            }
        }

        public bool IsSelectControlCollapsed
        {
            get
            {
                return _IsUserControl1Collapsed;
            }

            set
            {
                _IsUserControl1Collapsed = value;
            }
        }
    }
}
