using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class ChairViewModel
    {
        public ObservableCollection<Chair> ListChair { get; set; } = new ObservableCollection<Chair>();
        public ChairViewModel()
        {
            this.ListChair = new ObservableCollection<Chair>();
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var a in this.ListChair)
            {
                if (max < a.Id)
                {
                    max = a.Id;
                };
            }
            return max;
        }
    }
}