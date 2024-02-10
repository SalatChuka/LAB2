using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    class ChairDPO
    {
        public int Id { get; set; }
        public string Faculty { get; set; }
        public string ShortNameChair { get; set; }
        public string NameChair { get; set; }
        public ChairDPO() { }
        public ChairDPO(int id, string faculty, string ShortNameChair, string NameChair)
        {
            this.Id = id;
            this.Faculty = faculty;
            this.ShortNameChair = ShortNameChair;
            this.NameChair = NameChair;
        }
        public ChairDPO ShallowCopy()
        {
            return (ChairDPO)this.MemberwiseClone();
        }
        public ChairDPO CopyFromChair(Chair chair)
        {
            ChairDPO chairDPO = new ChairDPO();

            FacultyViewModel vmFaculty = new FacultyViewModel();
            string faculty = string.Empty;
            foreach (var agr in vmFaculty.ListFaculty)
            {
                if (agr.Id == chair.IdFaculty)
                {
                    faculty = agr.ShortNameFaculty;
                    break;
                }
            }

            if (faculty != string.Empty)
            {
                chairDPO.Id = chair.Id;
                chairDPO.Faculty = faculty;
                chairDPO.ShortNameChair = chair.ShortNameChair;
                chairDPO.NameChair = chair.NameChair;
            }
            return chairDPO;
        }

    }

}
