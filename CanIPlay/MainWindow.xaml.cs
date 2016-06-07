using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;

namespace CanIPlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
            
            Website website = new Website();
            website.InitDictionary();
            CurrentWebsite = website.listOfWebsites["GOOGLE"];
            DataContext = this;
            _timer = new Timer(2000);
            _timer.Elapsed += requestPing;
            _timer.Enabled = true;
        }

        private void requestPing(object sender, ElapsedEventArgs e)
        {
            Ping();
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

        private string _refreshStamp;

        public string RefreshStamp
        {
            get { return _refreshStamp; }
            set {
                if (value != _refreshStamp)
                {
                    _refreshStamp = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private void Ping()
        {
                if (CheckForInternetConnection(CurrentWebsite))
                {
                    CurrentStatus = "Connected";
                
                }
                else
                {
                    CurrentStatus = "Not connected";
                }

            RefreshStamp = DateTime.Now.ToString("HH:mm:ss");

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
