using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            IsLock = 0;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string _openid { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Uname { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Pwd { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string TrueName { get; set; }
        [MaxLength(2)]
        [Column(TypeName = "varchar")]
        public string Sex { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string role { get; set; }
        [Column(TypeName = "int")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        [MaxLength(11)]
        [Column(TypeName = "char")]
        public string Phone { get; set; }
        [Column(TypeName ="int")]
        public int IsLock { get; set; }
        public List<DaKaItem> DaKaIterms { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<QinJia> QinJias { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
