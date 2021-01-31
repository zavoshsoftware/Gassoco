using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class HomeViewModel:_LayoutViewModel
    {
      //  public List<Slider> Sliders { get; set; }
        public TextTypeItem WhyTitle { get; set; }
        public List<TextTypeItem> WhyTextItems { get; set; }
        public List<Product> Products { get; set; }
        public TextTypeItem AboutTextItem { get; set; }
        public TextTypeItem AboutTextItemSecond { get; set; }
        public List<Blog> RecentBlogs { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}