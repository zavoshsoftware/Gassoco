using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class Service:BaseEntity
    {
        public Service()
        {
            ServiceItems=new List<ServiceItem>();
        }
        [Display(Name = "عنوان خدمت")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        [Required(ErrorMessage = "لطفا عنوان {0} را وارد نمایید")]
        public string Title { get; set; }
        [Display(Name = "اولویت نمایش")]
        public int? Priority { get; set; }

        [Display(Name = "عنوان انگلیسی خدمت")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        [Required(ErrorMessage = "لطفا عنوان {0} را وارد نمایید")]
        public string TitleEn { get; set; }

        public virtual ICollection<ServiceItem> ServiceItems { get; set; }


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