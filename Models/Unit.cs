using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1262228_Arosh_NGJs.Models
{
    public class Unit
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public string Seat { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
