using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCMS.Models.Entities
{
    public class Contact
    {

        public int ContactId { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите DisplayOrder")]
        [Range(0, 9999, ErrorMessage = "Значение в DisplayOrder должно попадать в рамки от 0 до 9999")]
        public int DisplayOrder { get; set; }

        public string Text { get; set; }
    }
}