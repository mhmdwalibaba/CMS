﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class Login
    {
        [Key]
        public int LoginID { get; set; }

        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="لطفا نام کاربری را وارد کنید")]
        [MaxLength(250)]
        public string UserName { get; set;}

        [Display(Name = "ایمیل")]
        
        [MaxLength(250)]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا رمز عبور را وارد کنید")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
