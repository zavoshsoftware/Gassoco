using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace  Models
{
    public class CustomerGroup:BaseEntity
    {
        public CustomerGroup()
        {
            Customers=new List<Customer>();
        }
        [Display(Name = "گروه مشتری")]
        public string Title { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        internal class Configuration : EntityTypeConfiguration<Customer>
        {
            public Configuration()
            {
                HasRequired(p => p.CustomerGroup)
                    .WithMany(j => j.Customers)
                    .HasForeignKey(p => p.CustomerGroupId);
            }
        }
    }
}