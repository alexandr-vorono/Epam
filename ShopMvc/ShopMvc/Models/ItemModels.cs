using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMvc.Models
{
    public class ItemModels
    {
        
            [Required(ErrorMessage = "Название не может быть пустым")]
            [Display(Name = "Название")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Описание не может быть пустым")]
            [Display(Name = "Описание")]
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }
        
    }
}