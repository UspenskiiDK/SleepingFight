using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Login
    {
        [Required(ErrorMessage ="Введите логин")]
        public string login { get; set; }

        [Required(ErrorMessage ="Введите пароль")]
        public string Password { get; set; }
    }
}
