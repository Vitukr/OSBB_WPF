using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_WPF
{
    public class DataList<T>
    {
        public IList<T> DList { get; set; }
        public void SetDList(IList<T> list)
        {
            DList = list;
        }
    }
}
