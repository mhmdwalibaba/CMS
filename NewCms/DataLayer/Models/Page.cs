using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }
        [Display(Name = "عنوان خبر")]
        public int GroupID { get; set; }

        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا عنوان سفحه را وارد کنید")]
        [MaxLength(150)]
        public string Title { get; set; }


        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا توضیح مختصر را وارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }


        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا متن را وارد کنید")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }
        [Display(Name = "بازدید")]
        public int Visit { get; set; }


        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "اسلایدر")]
        public bool showInslider { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        public virtual IEnumerable<PageComment> PageComments { get; set; }
        public virtual PageGroup PageGroup { get; set; }

        public Page()
        {

        }

    }
}
