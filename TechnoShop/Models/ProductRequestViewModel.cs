﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TechnoShop.Models
{
    public class ProductRequestViewModel
    {
        [Required(ErrorMessage = "Необходимо заполнить поле с названием!")]
        [MaxLength(150, ErrorMessage = "Максимальная длинна строки - 150")]
        [Display(Name = "Название продукта")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле цены!")]
        [Display(Name = "Стоимость")]
        public double Cost { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле кол-ва продуктов!")]
        [Display(Name = "Кол-во продукта")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле описания!")]
        [MaxLength(600, ErrorMessage = "Максимальная длинна строки - 600")]
        [Display(Name = "Описание продукта")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать значение типа продукта!")]
        [Display(Name = "Тип продукта")]
        public string ProductTypeName { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить ссылку на фотографию продукта!")]
        [MaxLength(300, ErrorMessage = "Максимальная длинна строки - 300")]
        [Display(Name = "Ссылка на фотографию продукта")]
        public string PictureLink { get; set; }

        
        public ResponceStatusViewModel ResponceStatus { get; set; } = new();

        
    }
}
