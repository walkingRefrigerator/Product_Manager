using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Product_Manager
{
    //Класс объекта из бд
    public partial class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name ="Наименование продукта")]
        public string Name { get; set; }

        [Display(Name ="Описание продукта")]
        public string Description { get; set; }
    }
}
