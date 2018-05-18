using OSBB_WPF.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        private MvvmCommand getDataInvoiceElektros;
        public MvvmCommand GetDataInvoiceElektros
        {
            get
            {
                return getDataInvoiceElektros ??
                  (getDataInvoiceElektros = new MvvmCommand(obj =>
                  {
                      // to do
                      LoadData("InvoiceElectroApi");
                  }));
            }
        }

        private MvvmCommand getDataInvoiceGazs;
        public MvvmCommand GetDataInvoiceGazs
        {
            get
            {
                return getDataInvoiceGazs ??
                  (getDataInvoiceGazs = new MvvmCommand(obj =>
                  {
                      // to do
                      LoadData("InvoiceGazApi");
                  }));
            }
        }

        private MvvmCommand getDataInvoiceServices;
        public MvvmCommand GetDataInvoiceServices
        {
            get
            {
                return getDataInvoiceServices ??
                  (getDataInvoiceServices = new MvvmCommand(obj =>
                  {
                      // to do
                      LoadData("InvoiceServiceApi");
                  }));
            }
        }

        private MvvmCommand getDataInvoiceTels;
        public MvvmCommand GetDataInvoiceTels
        {
            get
            {
                return getDataInvoiceTels ??
                  (getDataInvoiceTels = new MvvmCommand(obj =>
                  {
                      // to do
                      LoadData("InvoiceTelApi");
                  }));
            }
        }

        private MvvmCommand getDataInvoiceWaters;
        public MvvmCommand GetDataInvoiceWaters
        {
            get
            {
                return getDataInvoiceWaters ??
                  (getDataInvoiceWaters = new MvvmCommand(obj =>
                  {
                      // to do
                      LoadData("InvoiceWaterApi");
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
                    case "InvoiceElectroApi":
                        DataObject = WebService.UseWebClient<InvoiceElectroApi>(@"http://vysoft.top/api/InvoiceElectroesApi", login, password);
                        break;
                    case "InvoiceGazApi":
                        DataObject = WebService.UseWebClient<InvoiceGazApi>(@"http://vysoft.top/api/InvoiceGazsApi", login, password);
                        break;
                    case "InvoiceServiceApi":
                        DataObject = WebService.UseWebClient<InvoiceServiceApi>(@"http://vysoft.top/api/InvoiceServicesApi", login, password);
                        break;
                    case "InvoiceTelApi":
                        DataObject = WebService.UseWebClient<InvoiceTelApi>(@"http://vysoft.top/api/InvoiceTelsApi", login, password);
                        break;
                    case "InvoiceWaterApi":
                        DataObject = WebService.UseWebClient<InvoiceWaterApi>(@"http://vysoft.top/api/InvoiceWatersApi", login, password);
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
