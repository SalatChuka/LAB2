using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindChair
    {
        int id;
        public FindChair(int id)
        {
            this.id = id;
        }
        public bool ChairPredicate(Chair chair)
        {
            return chair.Id == id;
        }
    }
}
