using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models
{
    public class Comment
    {
        Comment()
        {
            createTime = DateTime.Now;
        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Uname { get; set; }
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public Blog Blog { get; set; }
        public string Content { get; set; }
        public int ParentCommentID { get; set; }   //父评论ID
        public int ParentUserID { get; set; }     //父评论用户ID
        public int ReplyCommentID { get; set; }  //子评论ID
        public int ReplyUserID { get; set; }   //子评论用户ID
        public int CommentLevel { get; set; }  //评论等级   默认  1:一级   2：二级
        public DateTime createTime { get; set; }
        public int Status { get; set; }   //状态   0：逻辑删除   1：有效
    }
}
