using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Product_Manager
{
    public partial class Product
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name ="Наименование продукта")]
        public string Name { get; set; }
        [Display(Name ="Описание продукта")]
        public string Description { get; set; }
    }
}
