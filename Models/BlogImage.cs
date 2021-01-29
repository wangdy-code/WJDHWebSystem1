using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models
{
    public class BlogImage
    {
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [MaxLength(50)]
        [Column(TypeName ="varchar")]
        public string ImagePath { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }


    }
}
