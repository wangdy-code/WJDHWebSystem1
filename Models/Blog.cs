
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models
{
    public class Blog
    {
        public Blog()
        {
            createTime = DateTime.Now;
            if (DateTime.Parse(createTime.ToString("T")) >= DateTime.Parse("17:30:00") && DateTime.Parse(createTime.ToString("T")) <= DateTime.Parse("23:59:59"))
            {
                IsValid = 1;
            }
            else
            {
                IsValid = 0;
            }
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Column(TypeName ="text")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Plan { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createTime { get; set; }

        [Column(TypeName = "int")]
        public int zt { get; set; }

        [Column(TypeName = "int")]
        public int UserID { get; set; }
        public User User { get; set; }
        public List<BlogImage> BlogImages { get; set; }
        public List<Comment> Comments { get; set; }
        public int IsValid { get; set; }

    }
}
