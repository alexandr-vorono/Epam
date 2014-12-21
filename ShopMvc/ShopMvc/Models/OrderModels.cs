using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMvc.Models
{
    public class OrderModels
    {

        [Required(ErrorMessage = "Фамилия не может быть пустая")]
        [Display(Name = "Фамилия менеджера")]
        public string Manager { get; set; }

        [Required(ErrorMessage = "Фамилия не может быть пустая")]
        [Display(Name = "Фамилия клиента")]
        public string Client { get; set; }

        [Required(ErrorMessage = "Название не может  быть  пустым")]
        [Display(Name = "Название товара")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Сумма не может  быть  пустой")]
        [Display(Name = "Сумма заказа")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Количество не может  быть  пустым")]
        [Display(Name = "Количество  товаров в заказе")]
        public int Count { get; set; }


    }
}