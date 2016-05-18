using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateApp.Models
{
    [Bind(Include ="Name,Status")]
    [MetadataType(typeof(Kind_Validation))]
    public partial class Kind
    {

    }

    public class Kind_Validation
    {
        [Required(ErrorMessage ="Emlak türü boş bırakılamaz")]
        [StringLength(50,ErrorMessage ="Emlek türü 50 karakterden fazla olamaz")]
        [DisplayName("Emlak türü: ")]
        public string Name { get; set; }
        [DisplayName("Durumu: ")]
        public bool Status { get; set; }
    }
}