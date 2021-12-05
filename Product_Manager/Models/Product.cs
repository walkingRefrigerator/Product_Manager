using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Product_Manager
{
    public partial class Product
    {
        //public Product ()
        //{
        //    Id = Guid.NewGuid ();
        //}

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name ="Наименование продукта")]
        public string Name { get; set; }

        [Display(Name ="Описание продукта")]
        public string Description { get; set; }
    }
}
