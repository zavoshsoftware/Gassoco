using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class _MenuProductGroupViewModel
    {
        public List<ParentChildProductGroupViewModel> ParentChildProductGroupViewModel { get; set; }
        public List<ProductGroup> ProductGroupsWithoutChild { get; set; }
    }

    public class ParentChildProductGroupViewModel
    {
        public ProductGroup ParentProductGroup { get; set; }
        public List<ProductGroup> ProductGroups { get; set; }
        public bool IsLast { get; set; }
    }
}