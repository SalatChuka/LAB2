using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Chair
    {
        public int Id { get; set; }
        public int IdFaculty {  get; set; }
        public string ShortNameChair { get; set; }
        public string NameChair {  get; set; }
        public Chair() { }
        public Chair(int id, int IdFaculty, string ShortNameChair, string NameChair)
        {
            this.Id = id;
            this.IdFaculty = IdFaculty;
            this.ShortNameChair = ShortNameChair;
            this.NameChair = NameChair;
        }
        public Chair ShallowCopy()
        {
            return (Chair)this.MemberwiseClone();
        }
        
        public Chair CopyFromChairDPO(ChairDPO c)
        {
            FacultyViewModel vmFaculty = new FacultyViewModel();
            int falcultyId = 0;
            foreach (var b in vmFaculty.ListFaculty)
            {
                if (b.ShortNameFaculty == c.Faculty)
                {
                    falcultyId = b.Id;
                    break;
                }
            }

            if (falcultyId != 0)
            {
                this.Id = c.Id;
                this.IdFaculty = falcultyId;
                this.NameChair = c.NameChair;
                this.ShortNameChair = c.NameChair;
            }
            return this;
        }

    }

}