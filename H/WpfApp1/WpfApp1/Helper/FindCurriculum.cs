using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindCurriculum
    {
        int id;
        public FindCurriculum(int id)
        {
            this.id = id;   
        }
        public bool BankPredicate(Curriculum bank)
        {
            return bank.Id == id;
        }
    }
}
