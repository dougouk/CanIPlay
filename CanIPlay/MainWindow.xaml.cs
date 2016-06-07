using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CanIPlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        static string GOOGLE = "http://www.google.ca";

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            CurrentWebsite = GOOGLE;
            DataContext = this;
        }

        private string _currentWebsite;

        public string CurrentWebsite
        {
            get { return _currentWebsite; }
            set
            {
                if (value != _currentWebsite)
                {
                    _currentWebsite = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _currentStatus;

        public string CurrentStatus
        {
            get { return _currentStatus; }
            set
            {
                if (value != _currentStatus)
                {
                    _currentStatus = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void ContinousPing()
        {
            while (true)
            {
                if (CheckForInternetConnection(CurrentWebsite))
                {
                    CurrentStatus = "Connected";
                }
                else
                {
                    CurrentStatus = "Not connected";
                }
                Thread.Sleep(2000);
            }
        }

        private bool CheckForInternetConnection(string website)
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(website))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        protected virtual void NotifyPropertyChanged(
        [CallerMemberName] String propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
