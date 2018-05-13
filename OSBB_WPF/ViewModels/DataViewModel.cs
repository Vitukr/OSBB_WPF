using OSBB_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OSBB_WPF.ViewModels
{
    public class DataViewModel : INotifyPropertyChanged
    {
        public Binding dataBinding = new Binding();

        public DataViewModel()
        {
            dataBinding.Source = this;
        }

        private DataGrid dataGridModel;
        public DataGrid DataGridModel
        {
            get => dataGridModel ?? (dataGridModel = new DataGrid());
            set
            {
                if (value != dataGridModel)
                {
                    dataGridModel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private object dataObject;
        public object DataObject
        {
            get => dataObject ?? (dataObject = new object());
            set
            {
                if (value != dataObject)
                {
                    dataObject = value;
                    //NotifyPropertyChanged(nameof(Announs));
                    NotifyPropertyChanged();
                }
            }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                if (value != login)
                {
                    login = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // As sample
        private MvvmCommand getData;
        public MvvmCommand GetData
        {
            get
            {
                return getData ??
                  (getData = new MvvmCommand(obj =>
                  {
                      // to do
                  }));
            }
        }

        private MvvmCommand getDataAnnouncements;
        public MvvmCommand GetDataAnnouncements
        {
            get
            {
                return getDataAnnouncements ??
                  (getDataAnnouncements = new MvvmCommand(obj =>
                  {
                      // to do
                      //dataBinding = new Binding("DataObject");
                      //dataGridModel.SetBinding(ItemsControl.ItemsSourceProperty, dataBinding);
                      LoadData("AnnouncementApi");
                  }));
            }
        }

        private MvvmCommand getDataContributions;
        public MvvmCommand GetDataContributions
        {
            get
            {
                return getDataContributions ??
                  (getDataContributions = new MvvmCommand(obj =>
                  {
                      // to do
                      LoadData("ContributionApi");
                  }));
            }
        }

        public void LoadData(string dataName)
        {
            try
            {
                switch(dataName)
                {
                    case "AnnouncementApi":
                        DataObject = WebService.UseWebClient<AnnouncementApi>(@"http://vysoft.top/api/AnnouncementsApi", login, password);
                        break;
                    case "ContributionApi":
                        DataObject = WebService.UseWebClient<ContributionApi>(@"http://vysoft.top/api/ContributionsApi", login, password);
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
