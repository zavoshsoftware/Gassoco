using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Models
{
    public class Customer:BaseEntity
    {
        [Display(Name = "مشتری")]
        public string Title { get; set; }

        [Display(Name = "محل اجرا")]
        public string Place { get; set; }
        [Display(Name = "موضوع")]
        public string Subject { get; set; }
        [Display(Name = "تصویر")]
        public string ImageUrl { get; set; }
        [Display(Name = "گروه مشتری")]
        public Guid CustomerGroupId { get; set; }
        public virtual CustomerGroup CustomerGroup { get; set; }
        internal class configuration:EntityTypeConfiguration<Customer>
        {
            public configuration()
            {
                HasRequired(p => p.CustomerGroup).WithMany(t => t.Customers).HasForeignKey(p => p.CustomerGroupId);
            }
        }
           
    }
}