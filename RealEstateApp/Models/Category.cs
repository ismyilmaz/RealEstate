using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateApp.Models
{
    [Bind(Include ="Name,MetaDescription,Status")]
    [MetadataType(typeof(Category_Validation))]
    public partial class Category
    {
    }

    public class Category_Validation
    {
        [Required(ErrorMessage ="Kategori adı boş geçilemez")]
        [StringLength(50,ErrorMessage ="Kategori adı 50 karakteden fazla olamaz")]
        [DisplayName("Kategori Adı: ")]
        public string Name { get; set; }
        [DisplayName("Meta description: ")]
        public string MetaDescription { get; set; }
        [DisplayName("Durumu: ")]
        public bool Status { get; set; }
        //chage
        //change 2
    }
}