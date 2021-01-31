using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal static class DatabaseContextInitializer
    {
        static DatabaseContextInitializer()
        {

        }

        internal static void Seed(DatabaseContext databaseContext)
        {
            Guid roleId=Guid.NewGuid();
            
            InsertInnerSlider(databaseContext);
            InsertBaseRole(databaseContext, roleId);
            InsertBaseUser(databaseContext, roleId);
            InsertMainSlides(databaseContext);
            databaseContext.SaveChanges();

        }

        internal static void InsertBaseRole(DatabaseContext databaseContext, Guid roleId)
        {
            Role role = new Role()
            {
                Id = roleId,
                Title = "مدیر وب سایت",
                Name = "Administrator",
                SubmitDate = DateTime.Now,
                IsDelete = false
            };

            databaseContext.Roles.Add(role);
        }

        internal static void InsertBaseUser(DatabaseContext databaseContext, Guid roleId)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                RoleId = roleId,
                Username = "gasso",
                Password = "gasso2@1!3#",
                FirstName = "baseuser",
                LastName = "baseuser",
                SubmitDate = DateTime.Now,
                IsDelete = false
            };

            databaseContext.Users.Add(user);
        }
       
        internal static void InsertInnerSlider(DatabaseContext databaseContext)
        {
            TextType slideType = new TextType()
            {
                //
                Id = new Guid("2f4d1d33-5566-48c8-bfdd-1d15f93f7898"),
                Title ="اسلاید داخلی",
                IsDelete=false,
                SubmitDate=DateTime.Now,

            };
            databaseContext.TextTypes.Add(slideType);

            TextTypeItem slide = new TextTypeItem()
            {
                Id = new Guid("3be879cd-a54c-4014-a165-bba718252d7c"),
                Title = "اسلاید داخلی",
                IsDelete = false,
                SubmitDate = DateTime.Now,
                TextTypeId=slideType.Id,
                ImageUrl= "/images/gasso.jpg"
            };
            databaseContext.TextTypeItems.Add(slide);
        }

        internal static void InsertMainSlides(DatabaseContext databaseContext)
        {
            Slider slide1 = new Slider()
            {
                Id=Guid.NewGuid(),
                Title= "تجهیزات پخت نان",
                TitleEn= "Bread Machine",
                Summary= "شرکت گازسو به عنوان اولین و بزرگترین تولید کننده تجهیزات آشپزخانه صنعتی اکنون اقدام به تولید دستگاه های پخت نان کرده است.",
                SummaryEn= "Gas Co., Ltd., as the first and the largest manufacturer of industrial kitchen equipment, has now started to produce bread baking machines.",
                LinkTitle= "اطلاعات بیشتر",
                LinkTitleEn= "Learn More",
                Priority=3,
                SubmitDate=DateTime.Now,
                IsDelete=false,
                ImageUrl= "/images/slide/slide1.jpg",

            };
            databaseContext.Sliders.Add(slide1);
            databaseContext.SaveChanges();

            Slider slide2 = new Slider()
            {
                Id = Guid.NewGuid(),
                Title = "تجهیزات آشپزخانه صنعتی",
                TitleEn = "Industrial kitchen equipment",
                Summary = "شرکت گازسو با سال ها تجربه در زمینه تولید تجهیزات آشپزخانه های صنعتی، اکنون بزرگترین شرکت تولید کننده در این حوزه می باشد.",
                SummaryEn = "With many years of experience in producing industrial kitchen equipment, Gassoco is the largest producer in the field.",
                LinkTitle = "اطلاعات بیشتر",
                LinkTitleEn = "Learn More",
                Priority = 2,
                SubmitDate = DateTime.Now,
                IsDelete = false,
                ImageUrl = "/images/slide/slide2.jpg",

            };
            databaseContext.Sliders.Add(slide2);
            databaseContext.SaveChanges();

            Slider slide3 = new Slider()
            {
                Id = Guid.NewGuid(),
                Title = "گروه صنعتی گازسو",
                TitleEn = "GASSO COMPANY",
                Summary = "در گروه صنعتی گازسو، نامی ایرانی با فعالیت بین المللی و اعتبار جهانی، بر این باوریم که مصرف کنندگان محصولات گازسو با استقبال روز افزونشان، تنها شایسته بهترین ها هستند،",
                SummaryEn = "In the Gassoco Industrial Group, an Iranian name with international and global credentials, we believe that consumers of gas products, with their growing welcome, are merely worthy of the best.",
                LinkTitle = "اطلاعات بیشتر",
                LinkTitleEn = "Learn More",
                Priority = 1,
                SubmitDate = DateTime.Now,
                IsDelete = false,
                ImageUrl = "/images/slide/slide3.jpg",

            };
            databaseContext.Sliders.Add(slide3);
            databaseContext.SaveChanges();
        }
    }
}

