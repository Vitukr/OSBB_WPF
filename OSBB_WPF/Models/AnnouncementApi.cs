using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_WPF.Models
{
    public class AnnouncementApi /*: INotifyPropertyChanged*/
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public string UserName { get; set; }

        //private string _userName;

        //public string UserName { get { return _userName; } set { if (_userName != value) { _userName = value; NotifyPropertyChanged("_userName"); } } }

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
