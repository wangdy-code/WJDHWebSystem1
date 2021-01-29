using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public List<User> Users { get; set; }
    }
}
