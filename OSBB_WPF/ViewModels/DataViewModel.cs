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
        private Binding dataBinding = new Binding();

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
                    //NotifyPropertyChanged(nameof(DataGridModel));
                    NotifyPropertyChanged();
                }
            }
        }

        private IList<AnnouncementApi> announs;
        public IList<AnnouncementApi> Announs
        {
            get => announs ?? (announs = new List<AnnouncementApi>());
            set
            {
                if (value != announs)
                {
                    announs = value;
                    //NotifyPropertyChanged(nameof(Announs));
                    NotifyPropertyChanged();
                }
            }
        }

        private IList<ContributionApi> contribs;
        public IList<ContributionApi> Contribs
        {
            get => contribs ?? (contribs = new List<ContributionApi>());
            set
            {
                if (value != contribs)
                {
                    contribs = value;
                    //NotifyPropertyChanged(nameof(Contribs));
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
                      dataBinding = new Binding("Announs");
                      dataGridModel.SetBinding(ItemsControl.ItemsSourceProperty, dataBinding);
                      LoadDataAnnouncementApi();
                  }));
            }
        }

        public void LoadDataAnnouncementApi()
        {
            try
            {
                Announs = WebService.UseWebClient<AnnouncementApi>(@"http://vysoft.top/api/AnnouncementsApi", login, password);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
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
                      dataBinding = new Binding("Contribs");
                      dataGridModel.SetBinding(ItemsControl.ItemsSourceProperty, dataBinding);
                      LoadDataContributionApi();
                  }));
            }
        }

        public void LoadDataContributionApi()
        {
            try
            {
                Contribs = WebService.UseWebClient<ContributionApi>(@"http://vysoft.top/api/ContributionsApi", login, password);
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
