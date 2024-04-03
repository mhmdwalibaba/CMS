using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int CommentID { get; set; }
        [Display(Name = "خبر")]
        [Required(ErrorMessage = "لطفا خبر را وارد کنید")]
        public int PageID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Display(Name = "وبسایت")]
        [MaxLength(100)]
        public string WebSite { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا نظر را وارد کنید")]
        [MaxLength]
        public string CommentText { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime CreatedDate { get; set; }

        public virtual Page Page { get; set; }

        public PageComment()
        {

        }
    }
}
