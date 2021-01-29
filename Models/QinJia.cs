using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models
{
    public class QinJia
    {
        public QinJia()
        {
            createTime = DateTime.Now;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime createTime { get; set; }
        public int MyProperty { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public List<QinJiaImage> QinJiaImages { get; set; }
    }
}
