using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models
{
    [Table("DaKa")]
    public class DaKaItem
    {
        public DaKaItem()
        {
            if (createTime == DateTime.MinValue)
            {
                createTime = DateTime.Now;
            }
            
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string address { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string location { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime createTime { get; set; }
        [Column(TypeName = "int")]
        public int bq { get; set; }
        [Column(TypeName = "int")]
        public int zt { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User User { get; set; }

        [Column(TypeName = "int")]
        public int IsValid { get; set; }

    }
}
