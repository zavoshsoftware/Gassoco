using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Models
{
    public class ServiceItem : BaseEntity
    {
        [Display(Name = "عنوان زیر مجموعه خدمت")]
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "لطفا عنوان {0} را وارد نمایید")]
        [DataType(dataType: DataType.MultilineText)]
        public string Title { get; set; }
        [Display(Name = "عنوان خدمت")]
        [Required(ErrorMessage = "لطفا عنوان {0} را وارد نمایید")]
        public Guid ServiceId { get; set; }
        [Display(Name = "اولویت نمایش")]
        public int? Priority { get; set; }
        [Display(Name = "عنوان انگلیسی زیر مجموعه خدمت")]
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "لطفا عنوان {0} را وارد نمایید")]
        [DataType(dataType: DataType.MultilineText)]
        public string TitleEn { get; set; }
        public Service Service { get; set; }
        internal class configuration : EntityTypeConfiguration<ServiceItem>
        {
            public configuration()
            {
                HasRequired(p => p.Service).WithMany(t => t.ServiceItems).HasForeignKey(p => p.ServiceId);
            }
        }

        Helpers.GetCulture oGetCulture = new Helpers.GetCulture();

        [NotMapped]
        public string TitleSrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.TitleEn;
                    case "fa-ir":
                        return this.Title;
                    default:
                        return String.Empty;
                }
            }
        }
    }
}