using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudents.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public int IdNo { get; set; }
        public int EmailAddress { get; set; }
        public int Gender { get; set; }
        public int Title { get; set; }
        public int Province { get; set; }
        public int City { get; set; }
        public int Ethic { get; set; }
        public int Nationalitys { get; set; }

        public int Department { get; set; }
    }
}
